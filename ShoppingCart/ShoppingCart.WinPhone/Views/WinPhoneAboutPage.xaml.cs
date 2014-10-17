using Microsoft.Phone.Controls;
using System;
using System.Linq;

namespace ShoppingCart.WinPhone.Views
{
    public partial class WinPhoneAboutPage : PhoneApplicationPage
    {
        public WinPhoneAboutPage()
        {
            this.DataContext = ShoppingCart.App.AboutViewModel;
            InitializeComponent();
        }
    }
}