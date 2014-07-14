using ShoppingCart.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigation _navi;

        public MainViewModel(INavigation navi)
        {
            _navi = navi;
        }

        public ICommand GoToLoginPageCommand
        {
            get { return new SimpleCommand(() => _navi.PushAsync(App.LoginPage)); }
        }
    }
}