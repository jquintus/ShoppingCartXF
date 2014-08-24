using ShoppingCart.Async;
using ShoppingCart.Models;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private const string _resource = "ShoppingCart.Resources.placeholderImageSmall.png";

        public ProductViewModel(Product product)
        {
            Product = product;
            IconSource = AsyncImageSource.FromUriAndResource(product.IconUrl, _resource);
        }

        public NotifyTaskCompletion<ImageSource> IconSource { get; private set; }

        public Product Product
        {
            get { return GetValue<Product>(); }
            set { SetValue(value); }
        }
    }
}