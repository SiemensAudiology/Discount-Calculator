namespace DiscountCalculator.API.Repository
{
    public class UserRepository
    {
        private static readonly Tuple<string, string>[] validUsers = new Tuple<string, string>[]
        {
            new Tuple<string, string>("Adam", "passAdam123"),
            new Tuple<string, string>("John", "passJohn123"),
            new Tuple<string, string>("Mary", "passMary123"),
            new Tuple<string, string>("Daniel", "passDaniel123")
        };
        
        private static bool isLoggedIn = false;

        public static bool CanLogin(string username, string password) 
        { 
            return validUsers.Any(x => x.Item1.Equals(username) && x.Item2.Equals(password)); 
        }

        public bool Login(string username, string password)
        {
            if (CanLogin(username, password))
            {
                isLoggedIn = true;
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            isLoggedIn = false;
            return true;
        }

        public bool IsLoggedIn()
        {
            return isLoggedIn;
        }
    }
}
