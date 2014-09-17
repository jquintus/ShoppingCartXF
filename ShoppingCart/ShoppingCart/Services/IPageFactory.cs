using Xamarin.Forms;

namespace ShoppingCart.Services
{
    public enum Pages
    {
        Login,
        Welcome,
        Categories,
    }

    public interface IPageFactory
    {
        Page GetPage(Pages page);
    }
}