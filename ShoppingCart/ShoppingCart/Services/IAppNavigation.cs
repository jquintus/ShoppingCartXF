using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IAppNavigation
    {
        Task ShowProductList(List<Product> items, string title, bool canShowSinglePage = false);
    }
}