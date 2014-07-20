using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class LoginService : ILoginService
    {
        public Task<bool> LoginAsync(string username, string password)
        {
            return Task.FromResult(Login(username, password));
        }

        private static bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (username.Contains("fake")) return false;

            return true;
        }
    }
}