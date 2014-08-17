using ShoppingCart.Async;
using ShoppingCart.Models;
using ShoppingCart.Services;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;

        public ProductViewModel(INavigationService navi, Product product)
        {
            _navi = navi;
            Product = product;
            IconSource = AsyncImageSource.FromUriAndResource(product.IconUrl, "ShoppingCart.Resources.placeholderImageSmall.png");
        }

        public NotifyTaskCompletion<ImageSource> IconSource { get; private set; }

        public Product Product
        {
            get { return GetValue<Product>(); }
            set { SetValue(value); }
        }
    }
}