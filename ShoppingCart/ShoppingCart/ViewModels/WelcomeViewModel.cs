using ShoppingCart.Mvvm;
using ShoppingCart.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class WelcomeViewModel
    {
        private readonly INavigation _navi;

        public WelcomeViewModel(INavigationService navi)
        {
            _navi = navi;
        }

        public ICommand GoToLoginPageCommand
        {
            get { return new SimpleCommand(() => _navi.PushAsync(App.LoginPage)); }
        }
    }
}