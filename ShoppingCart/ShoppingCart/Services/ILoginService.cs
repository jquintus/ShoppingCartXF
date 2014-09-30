using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ILoginService
    {
        Task<User> LoginAsync(string username, string password);
    }
}