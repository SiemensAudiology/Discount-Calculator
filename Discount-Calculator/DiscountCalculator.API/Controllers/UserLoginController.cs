using DiscountCalculator.API.DTO;
using DiscountCalculator.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountCalculator.API.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly DiscountCalculatorRepository discountCalculatorRepository;

        public UserLoginController(UserRepository userRepository, DiscountCalculatorRepository discountCalculatorRepository)
        {
            this.userRepository = userRepository;
            this.discountCalculatorRepository = discountCalculatorRepository;
        }

        // POST api/<UserLoginController>
        [HttpPost("Login")]
        public IActionResult Post([FromBody] Login login)
        {
            if (userRepository.Login(login.Username, login.Password))
            {
                return StatusCode(200, "Logged in Successfully");
            }
            
            return Unauthorized("Invalid Credentials");
        }
    }
}
