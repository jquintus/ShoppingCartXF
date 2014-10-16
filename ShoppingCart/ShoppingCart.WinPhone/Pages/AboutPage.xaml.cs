using Microsoft.Phone.Controls;
using System;
using System.Linq;

namespace ShoppingCart.WinPhone.Pages
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