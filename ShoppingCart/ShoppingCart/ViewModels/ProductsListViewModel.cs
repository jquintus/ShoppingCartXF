using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class ProductsListViewModel : BaseViewModel
    {
        private readonly IAppNavigation _navi;

        public ProductsListViewModel(IAppNavigation navi)
        {
            _navi = navi;
            Title = "Products Page";

            MessagingCenter.Subscribe<Product>(this, Messages.NavigateTo, NavigateToProduct);
        }

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

        private async void NavigateToProduct(Product product)
        {
            await _navi.ShowProduct(product);
        }
    }
}