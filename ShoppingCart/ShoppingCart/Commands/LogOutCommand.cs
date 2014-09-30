using ShoppingCart.Services;
using System;
using System.Linq;
using System.Windows.Input;

namespace ShoppingCart.Commands
{
    public class LogOutCommand : ICommand
    {
        private readonly ILoginService _login;
        private readonly IAppNavigation _navi;
        private bool _canExecute;

        public LogOutCommand(ILoginService login, IAppNavigation navi)
        {
            _login = login;
            _navi = navi;
            _canExecute = true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public async void Execute(object parameter)
        {
            try
            {
                _canExecute = false;
                CanExecuteChanged(this, EventArgs.Empty);

                await _login.LogOutAsync();
                await _navi.ShowLogin();
            }
            finally
            {
                _canExecute = true;
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}