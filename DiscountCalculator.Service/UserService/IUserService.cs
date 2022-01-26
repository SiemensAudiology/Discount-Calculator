using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator.Service
{
    public interface IUserService
    {
        Task LoginUser(string username, string password);
        bool CheckUserLoggedIn(string username);
    }
}
