using ShoppingCart.Async;
using ShoppingCart.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingCart.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private readonly IAppNavigation _navi;
        private SemaphoreSlim _slim;

        public WelcomeViewModel(IAppNavigation navi)
        {
            _navi = navi;
            _slim = new SemaphoreSlim(0, 1);
            IsBusy = new NotifyTaskCompletion<int>(GoToFirstPage());
        }

        public NotifyTaskCompletion<int> IsBusy { get; private set; }

        public bool IsLoaded
        {
            get { return GetValue<bool>(); }
            set
            {
                SetValue(value);
                if (value)
                {
                    _slim.Release();
                }
            }
        }

        private async Task<int> GoToFirstPage()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));  // This is just here so I can get a video of this at startup.
            await _slim.WaitAsync();
            await _navi.ShowLogin();
            return 0;
        }
    }
}