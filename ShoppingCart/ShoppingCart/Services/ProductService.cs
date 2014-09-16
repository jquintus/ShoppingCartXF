using ShoppingCart.Async;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ProductService : IProductService
    {
        private readonly AsyncLazy<List<Product>> _itemsAsync;
        private readonly IProductLoader _loader;

        public ProductService(IProductLoader loader)
        {
            _loader = loader;
            _itemsAsync = new AsyncLazy<List<Product>>(async () => await _loader.LoadProducts());
        }

        public async Task<List<Category>> GetCategories()
        {
            var items = await _itemsAsync;

            var cats = items.GroupBy(i => i.Category)
                            .Select(g => new Category
                            {
                                Name = g.Key,
                                Count = g.Count()
                            })
                            .OrderBy(c => c.Name)
                            .ToList();

            return cats;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _itemsAsync;
        }

        public async Task<List<Product>> GetProductsForCategory(string category)
        {
            var items = await _itemsAsync;
            var filterd = items.Where(i => string.Equals(category, i.Category, StringComparison.CurrentCultureIgnoreCase))
                               .ToList();

            return filterd;
        }

        public async Task<List<Product>> Search(string searchString)
        {
            var items = await _itemsAsync;

            if (string.IsNullOrWhiteSpace(searchString)) return items;

            searchString = searchString.ToLower();
            var filterd = items.Where(i => i.Name.ToLower().Contains(searchString))
                               .ToList();

            return filterd;
        }
    }
}