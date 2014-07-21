using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IProductLoader
    {
        Task<List<Item>> LoadProducts();
    }
}