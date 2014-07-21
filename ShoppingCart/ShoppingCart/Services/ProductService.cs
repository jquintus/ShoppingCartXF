using ShoppingCart.Models;
using ShoppingCart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ProductService : IProductService
    {
        private readonly AsyncLazy<List<Item>> _itemsAsync;
        private readonly IProductLoader _loader;

        public ProductService(IProductLoader loader)
        {
            _loader = loader;
            _itemsAsync = new AsyncLazy<List<Item>>(async () => await _loader.LoadProducts());
        }

        public async Task<List<string>> GetCategories()
        {
            var items = await _itemsAsync;
            var cats = items.Select(i => i.Category)
                            .Distinct(StringComparer.CurrentCultureIgnoreCase)
                            .OrderBy(s => s)
                            .ToList();

            return cats;
        }

        public async Task<List<Item>> GetProducts()
        {
            return await _itemsAsync;
        }

        public async Task<List<Item>> GetProductsForCategory(string category)
        {
            var items = await _itemsAsync;
            var filterd = items.Where(i => string.Equals(category, i.Category, StringComparison.CurrentCultureIgnoreCase))
                               .ToList();

            return filterd;
        }

        public async Task<List<Item>> Search(string searchString)
        {
            var items = await _itemsAsync;

            if (string.IsNullOrWhiteSpace(searchString)) return items;

            return new List<Item>();
        }
    }
}