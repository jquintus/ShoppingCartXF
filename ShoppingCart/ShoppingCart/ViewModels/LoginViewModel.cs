using ShoppingCart.Mvvm;
using ShoppingCart.Services;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;

        private string _password;
        private string _username;

        public LoginViewModel(ILoginService loginService, INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ICommand LoginCommand { get { return new SimpleCommand(Login); } }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private async void Login()
        {
            bool result = await _loginService.LoginAsync(Username, Password);

            if (result)
            {
                await _navigationService.PopAsync();
            }
            else
            {
                await _navigationService.DisplayAlert("Error", "Invalid username or password", "ok");
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}