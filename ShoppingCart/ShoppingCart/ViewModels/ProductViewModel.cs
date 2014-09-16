using ShoppingCart.Async;
using ShoppingCart.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private const string _resource = "ShoppingCart.Resources.placeholderImageSmall.png";

        public ProductViewModel(Product product, ICommand navigateToProduct)
        {
            Product = product;
            IconSource = AsyncImageSource.FromUriAndResource(product.IconUrl, _resource);
            NavigateToProduct = navigateToProduct;
        }

        public NotifyTaskCompletion<ImageSource> IconSource { get; private set; }

        public ICommand NavigateToProduct { get; private set; }

        public Product Product
        {
            get { return GetValue<Product>(); }
            set { SetValue(value); }
        }
    }
}