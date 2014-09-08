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
            AccentColor = Xamarin.Forms.Color.Accent;
        }

        public Color AccentColor { get; private set; }
    }
}