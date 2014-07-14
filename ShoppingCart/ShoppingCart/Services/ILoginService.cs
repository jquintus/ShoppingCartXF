using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}