using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenUrlCommand = new Command<string>(s => Device.OpenUri(new Uri(s)));
        }

        public ICommand OpenUrlCommand { get; private set; }
    }
}