using GalaSoft.MvvmLight.Command;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace ShoppingCart.ViewModels
{
    public class ProductsListViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;

        public ProductsListViewModel(INavigationService navi)
        {
            _navi = navi;
            Title = "Products Page";

            NavigateToProduct = new RelayCommand<ProductViewModel>(async item =>
                {
                    var page = App.GetProductPage(item);
                    await _navi.PushAsync(page);
                },
                item => item != null);
        }

        public ICommand NavigateToProduct { get; private set; }

        public List<ProductViewModel> Products
        {
            get { return GetValue<List<ProductViewModel>>(); }
            set { SetValue(value); }
        }

        public string Title
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}