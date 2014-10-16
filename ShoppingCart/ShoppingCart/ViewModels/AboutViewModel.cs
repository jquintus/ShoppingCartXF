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

        public string BlogUrl { get { return @"http://blog.masterdevs.com/xf-day-10/"; } }

        public string CodeUrl { get { return @"https://github.com/jquintus/spikes/tree/master/XamarinSpikes/ShoppingCart"; } }

        public ICommand OpenUrlCommand { get; private set; }
    }
}