using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ILoginService
    {
        Task<bool> IsLoggedIn();

        Task<User> LoginAsync(string username, string password);

        Task LogOutAsync();
    }
}