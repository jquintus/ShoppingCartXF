using Microsoft.Phone.Controls;
using System;
using System.Linq;

namespace ShoppingCart.WinPhone.Views
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            this.DataContext = ShoppingCart.App.AboutViewModel;
            InitializeComponent();
        }
    }
}