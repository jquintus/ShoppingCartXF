using GalaSoft.MvvmLight.Command;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ShoppingCart.ViewModels
{
    public class CategoriesListViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;
        private readonly IProductService _service;

        public CategoriesListViewModel(IProductService service, INavigationService navi)
        {
            _service = service;
            _navi = navi;

            Items = new NotifyTaskCompletion<List<Item>>(_service.GetProducts());
            Categories = new NotifyTaskCompletion<List<string>>(_service.GetCategories());

            NavigateToCategory = new RelayCommand<string>(async cat =>
            {
                var items = (await _service.GetProductsForCategory(cat))
                    .OrderByDescending(i => i.Rating)
                    .ToList();

                if (items != null && items.Any())
                {
                    await _navi.PushAsync(App.GetProductsListPage(items));
                }
                else
                {
                    await _navi.DisplayAlert("Error", "There are no items in the category " + cat);
                }
            });
        }

        public NotifyTaskCompletion<List<string>> Categories { get; private set; }

        public NotifyTaskCompletion<List<Item>> Items { get; private set; }

        public ICommand NavigateToCategory { get; private set; }
    }
}