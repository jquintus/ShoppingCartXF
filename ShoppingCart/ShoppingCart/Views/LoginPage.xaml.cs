using ShoppingCart.ViewModels;
using Xamarin.Forms;

namespace ShoppingCart.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel lvm)
        {
            InitializeComponent();
            BindingContext = lvm;
        }
    }
}