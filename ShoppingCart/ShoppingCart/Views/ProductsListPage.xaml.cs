using ShoppingCart.Models;
using ShoppingCart.ViewModels;
using Xamarin.Forms;

namespace ShoppingCart.Views
{
    public partial class ProductsListPage
    {
        public ProductsListPage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var param = e.SelectedItem as Item;
            var command = ((ProductsListViewModel)BindingContext).NavigateToProduct;

            if (command.CanExecute(param))
            {
                command.Execute(param);
            }
        }
    }
}