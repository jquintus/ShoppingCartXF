using ShoppingCart.Mvvm;
using ShoppingCart.Services;
using System.Windows.Input;

namespace ShoppingCart.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private readonly IAppNavigation _navigationService;

        public LoginViewModel(ILoginService loginService, IAppNavigation navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
        }

        public ICommand LoginCommand { get { return new SimpleCommand(Login); } }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        public string Username
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        private async void Login()
        {
            var result = await _loginService.LoginAsync(Username, Password);

            await _navigationService.LoggedIn(result != null);

        }
    }
}