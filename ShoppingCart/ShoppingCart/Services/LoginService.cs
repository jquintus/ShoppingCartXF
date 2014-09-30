using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICache _cache;

        public LoginService(ICache cache)
        {
            _cache = cache;
        }

        public bool IsLoggedIn()
        {
            var t = _cache.GetObject<User>("LOGIN");
            t.Wait();
            var user = t.Result;
            return user == null;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var u = Login(username, password);

            await _cache.InsertObject("LOGIN", u);

            return u;
        }

        private static User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            if (username.Contains("fake")) return null;

            return new User { Name = username, Password = password };
        }
    }
}