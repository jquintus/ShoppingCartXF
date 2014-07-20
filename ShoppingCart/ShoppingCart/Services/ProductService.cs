using ShoppingCart.Models;
using ShoppingCart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ProductService
    {
        private readonly AsyncLazy<List<Item>> _itemsAsync;

        public ProductService()
        {
            _itemsAsync = new AsyncLazy<List<Item>>(async () => await LoadItems());
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

        public async Task<List<Item>> GetItemsForCategory(string category)
        {
            var items = await _itemsAsync;
            var filterd = items.Where(i => string.Equals(category, i.Category, StringComparison.CurrentCultureIgnoreCase))
                               .ToList();

            return filterd;
        }

        private Task<List<Item>> LoadItems()
        {
            throw new NotImplementedException();
        }
    }
}