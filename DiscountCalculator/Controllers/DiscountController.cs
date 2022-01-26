using DiscountCalculator.Service;
using DiscountCalculator.Service.DiscountService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiscountCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDiscountService _discountService;

        public DiscountController(IUserService userService, IDiscountService discountService)
        {
            _userService = userService;
            _discountService = discountService;
        }

        [HttpGet("login")]
        public async Task<ObjectResult> Login([FromQuery] string username, [FromQuery] string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return BadRequest("Username & password is required");
            await _userService.LoginUser(username, password);

            return Ok("Login Successful");
        }

        [HttpGet("calculate")]
        public ObjectResult CalculatePrice([FromQuery] string username, [FromQuery] int goldPrice, [FromQuery] int weight, [FromQuery] int discount = 0)
        {
            if (string.IsNullOrEmpty(username) || goldPrice == 0 || weight == 0)
                return BadRequest("invalid request");
            var authorisedUser = _userService.CheckUserLoggedIn(username);
            if (!authorisedUser)
                return Unauthorized("user must be login to access this method");

            var result = _discountService.CalculatePrice(goldPrice, weight, discount);

            return Ok(result);
        }

    }
}
