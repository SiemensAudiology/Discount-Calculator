using DiscountCalculator.Controllers;
using DiscountCalculator.Service;
using DiscountCalculator.Service.DiscountService;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator.Tests
{
    class DiscountControllerTests
    {

        private DiscountController _sut;
        private Mock<IUserService> _userService;
        private Mock<IDiscountService> _discountService;

        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
            _discountService = new Mock<IDiscountService>();
            _sut = new DiscountController(_userService.Object, _discountService.Object);
        }

        [Test]
        public async Task VerifyLogin_LoginSuccess()
        {
            _userService.Setup(n => n.LoginUser(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var response = await _sut.Login("test", "1145");

            Assert.True(response.StatusCode == 200);
            _userService.Verify(n => n.LoginUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task VerifyLogin_LoginFail()
        {
            var response = await _sut.Login("", "");
            Assert.True(response.StatusCode == 400);
        }

        [Test]
        public void VerifyCalculatePrice_ReturnBadRequest()
        {
            var response = _sut.CalculatePrice("", 0, 0);
            Assert.True(response.StatusCode == 400);
        }

        [Test]
        public void VerifyCalculatePrice_ReturnUnauthorizedWhenUserIsNotLoggedIn()
        {
            _userService.Setup(n => n.CheckUserLoggedIn(It.IsAny<string>())).Returns(false);

            var response = _sut.CalculatePrice("test", 100, 10);

            Assert.True(response.StatusCode == 401);
            _userService.Verify(n => n.CheckUserLoggedIn(It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void VerifyCalculatePrice_ReturnPrice()
        {
            _userService.Setup(n => n.CheckUserLoggedIn(It.IsAny<string>())).Returns(true);
            _discountService.Setup(n => n.CalculatePrice(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(10000);

            var response = _sut.CalculatePrice("test", 1000, 10);

            Assert.True(response.StatusCode == 200);
            Assert.True((int)response.Value == 10000);
            _discountService.Verify(n => n.CalculatePrice(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
