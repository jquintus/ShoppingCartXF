using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IProductService
    {
        Task<List<string>> GetCategories();

        Task<List<Item>> GetProducts();

        Task<List<Item>> GetProductsForCategory(string category);

        Task<List<Item>> Search(string searchString);
    }
}