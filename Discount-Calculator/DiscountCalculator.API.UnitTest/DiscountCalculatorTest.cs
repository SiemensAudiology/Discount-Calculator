using DiscountCalculator.API.Controllers;
using DiscountCalculator.API.DTO;
using DiscountCalculator.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DiscountCalculator.API.UnitTest
{
    public class DiscountCalculatorTest
    {
        private readonly DiscountCalculatorRepository discountCalculatorRepository;
        private readonly UserRepository userRepository;
        private readonly DiscountCalculatorController discountCalculatorController;
        private readonly UserLoginController userLoginController;

        public DiscountCalculatorTest()
        {
            this.discountCalculatorRepository = new DiscountCalculatorRepository();
            this.userRepository = new UserRepository();
            this.discountCalculatorController = new DiscountCalculatorController(userRepository, discountCalculatorRepository);
            this.userLoginController = new UserLoginController(userRepository, discountCalculatorRepository);
        }

        [Fact]
        public void Test_LoggedIn_User_Can_Calculate_Discount()
        {
            //Assign
            DiscountPriceRequest discountPriceRequest = new DiscountPriceRequest(100m, 1m, 5m);
            DiscountPriceResponse discountPriceResponse = new DiscountPriceResponse(discountPriceRequest, 95m);
            Login login = new Login("Adam", "passAdam123");

            //Act
            userLoginController.Post(login);
            var response = discountCalculatorController.Post(discountPriceRequest);

            //Assert
            var result = response.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.True(result?.StatusCode == (int)HttpStatusCode.OK);

            var discountPrice = result?.Value as DiscountPriceResponse;
            Assert.True(discountPrice?.TotalPrice == discountPriceResponse.TotalPrice);
        }

        [Fact]
        public void Test_UnAuthorized_User_Cannot_Calculate_Discount()
        {
            //Assign
            DiscountPriceRequest discountPriceRequest = new DiscountPriceRequest(100m, 1m, 5m);
            DiscountPriceResponse discountPriceResponse = new DiscountPriceResponse(discountPriceRequest, 95m);
            //Act
            var response = discountCalculatorController.Post(discountPriceRequest);

            //Assert
            var result = response.Result as UnauthorizedObjectResult;
            Assert.NotNull(result);
            Assert.True(result?.StatusCode == (int)HttpStatusCode.Unauthorized);
            Assert.True(result?.Value?.ToString() == "User not logged in");
        }
    }
}
