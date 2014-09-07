using ShoppingCart.Services;
using Xamarin.Forms;

namespace ShoppingCart.Droid.Services
{
    public class DroidThemer : IThemer
    {
        public DroidThemer()
        {
            var color = Forms.Context.Resources.GetColor(Resource.Color.apptheme_color);

            AccentColor = Color.FromRgba(color.R, color.G, color.B, color.A);
        }

        public Xamarin.Forms.Color AccentColor { get; private set; }
    }
}