using ShoppingCart.Services;
using System;
using System.Linq;
using System.Windows.Input;

namespace ShoppingCart.Commands
{
    public class LogOutCommand : ICommand
    {
        private readonly ILoginService _login;
        private readonly INavigationService _navi;
        private readonly IPageFactory _pageFactory;
        private bool _canExecute;

        public LogOutCommand(ILoginService login, INavigationService navi, IPageFactory pageFactory)
        {
            _login = login;
            _navi = navi;
            _pageFactory = pageFactory;
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
                var page = _pageFactory.GetStartPage();
                await _navi.PushAsync(page);
            }
            finally
            {
                _canExecute = true;
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}