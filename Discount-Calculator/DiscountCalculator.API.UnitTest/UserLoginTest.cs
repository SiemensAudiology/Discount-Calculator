using DiscountCalculator.API.Controllers;
using DiscountCalculator.API.DTO;
using DiscountCalculator.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace DiscountCalculator.API.UnitTest
{
    public class UserLoginTest
    {
        private readonly DiscountCalculatorRepository discountCalculatorRepository;
        private readonly UserRepository userRepository;
        private readonly UserLoginController userLoginController;

        public UserLoginTest()
        {
            this.discountCalculatorRepository = new DiscountCalculatorRepository();
            this.userRepository = new UserRepository();
            this.userLoginController = new UserLoginController(userRepository, discountCalculatorRepository);
        }

        [Fact]
        public void Test_When_Valid_User_Login_Successfully()
        {
            //Assign
            Login login = new Login("Adam", "passAdam123");

            //Act
            var response = userLoginController.Post(login);

            //Assert
            var result = response as ObjectResult;
            Assert.NotNull(result);
            Assert.True(result?.StatusCode == (int)HttpStatusCode.OK);
            Assert.True(result?.Value?.ToString() == "Logged in Successfully");
        }
        [Fact]
        public void Test_When_Not_Valid_User_Login_Unsuccessful()
        {
            //Assign
            Login login = new Login("John", "John123");

            //Act
            var response = userLoginController.Post(login);

            //Assert
            var result = response as ObjectResult;
            Assert.NotNull(result);
            Assert.True(result?.StatusCode == (int)HttpStatusCode.Unauthorized);
            Assert.True(result?.Value?.ToString() == "Invalid Credentials");
        }
    }
}