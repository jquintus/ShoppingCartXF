using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;

namespace ShoppingCart.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        private readonly IProductService _service;

        public ProductListViewModel(IProductService service)
        {
            _service = service;

            Items = new NotifyTaskCompletion<List<Item>>(_service.GetProducts());
            Categories = new NotifyTaskCompletion<List<string>>(_service.GetCategories());

        }

        public NotifyTaskCompletion<List<string>> Categories { get; private set; }

        public NotifyTaskCompletion<List<Item>> Items { get; private set; }
    }
}