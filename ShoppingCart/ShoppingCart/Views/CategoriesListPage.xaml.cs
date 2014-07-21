using ShoppingCart.ViewModels;
using Xamarin.Forms;

namespace ShoppingCart.Views
{
    public partial class CategoriesListPage
    {
        public CategoriesListPage()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((CategoriesListViewModel)BindingContext).NavigateToCategory.Execute(e.SelectedItem as string);
        }
    }
}