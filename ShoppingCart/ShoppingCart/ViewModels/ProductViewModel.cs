using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;

        public ProductViewModel(INavigationService navi)
        {
            _navi = navi;
        }

        public Item Product
        {
            get { return GetValue<Item>(); }
            set { SetValue(value); }
        }
    }
}