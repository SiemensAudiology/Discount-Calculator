using DiscountCalculator.API.DTO;
using DiscountCalculator.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCalculatorController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly DiscountCalculatorRepository discountCalculatorRepository;

        public DiscountCalculatorController(UserRepository userRepository, DiscountCalculatorRepository discountCalculatorRepository)
        {
            this.userRepository = userRepository;
            this.discountCalculatorRepository = discountCalculatorRepository;
        }

        // POST api/<DiscountCalculatorController>
        [HttpPost]
        public ActionResult<DiscountPriceResponse> Post([FromBody] DiscountPriceRequest discountPrice)
        {
            if (userRepository.IsLoggedIn())
            {
                var totalPrice =  discountCalculatorRepository.CalculateTotalPrice(discountPrice.GoldPrice, discountPrice.Discount, discountPrice.Weight);

                return new DiscountPriceResponse(discountPrice, totalPrice);
            }

            return Unauthorized("User not logged in");
        }

    }
}
