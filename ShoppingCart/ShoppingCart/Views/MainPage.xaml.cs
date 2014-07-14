using ShoppingCart.ViewModels;
using Xamarin.Forms;

namespace ShoppingCart.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mvm)
        {
            InitializeComponent();

            BindingContext = mvm;
        }
    }
}