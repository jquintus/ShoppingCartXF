using Xamarin.Forms;

namespace ShoppingCart.Views
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = "About";

            Content = new Label
            {
                Text = "This page is not available for your platform",
            };
        }
    }
}