using DiscountCalculator.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountCalculator.API.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/<UserLoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserLoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserLoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserLoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserLoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
