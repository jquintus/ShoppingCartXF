using ShoppingCart.Services;
using System.Windows;

namespace ShoppingCart.WinPhone.Services
{
    public class WinPhoneThemer : IThemer
    {
        public WinPhoneThemer()
        {
            var color = (System.Windows.Media.Color)Application.Current.Resources["PhoneAccentColor"];
            AccentColor = Xamarin.Forms.Color.FromRgba(color.R, color.G, color.B, color.A);
        }

        public Xamarin.Forms.Color AccentColor { get; private set; }
    }
}