using DiscountCalculator.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCalculator.Service
{
    public class UserService : IUserService
    {
        private readonly ApiContext _dbContext;
        
        public UserService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckUserLoggedIn(string username)
        {
            return _dbContext.Users.Any(n => string.Equals(n.Username, username, StringComparison.CurrentCultureIgnoreCase) && n.LoggedIn);
        }

        public async Task LoginUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(n => string.Equals(n.Username, username, StringComparison.CurrentCultureIgnoreCase));
            if (user == null)
            {
                var userModel = new User()
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    Password = password,
                    LoggedIn = true
                };
                _dbContext.Users.Add(userModel);
            }
            else
            {
                user.LoggedIn = true;
            }
          await  _dbContext.SaveChangesAsync();
        }
    }
}
