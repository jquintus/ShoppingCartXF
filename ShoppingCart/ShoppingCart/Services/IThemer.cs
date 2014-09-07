using System;
using Xamarin.Forms;

namespace ShoppingCart.Services
{
    public interface IThemer
    {
        Color AccentColor { get; }
    }

    public class NullThemer : IThemer
    {
        public NullThemer()
        {
            // Generate a random color for the accent.
            var random = new Random();

            int r = random.Next(150);
            int g = random.Next(150);
            int b = random.Next(150);

            AccentColor = Color.FromRgb(r, g, b);
        }

        public Color AccentColor { get; private set; }
    }
}