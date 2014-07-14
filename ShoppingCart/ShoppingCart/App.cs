using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using Xamarin.Forms;

namespace ShoppingCart
{
    public class App
    {
        static App()
        {
            ILoginService login = new LoginService();
            NavigationService navi = new NavigationService();

            MainViewModel mvm = new MainViewModel(navi);
            LoginViewModel lvm = new LoginViewModel(login, navi);

            MainPage = new NavigationPage(new MainPage(mvm));
            LoginPage = new NavigationPage(new LoginPage(lvm));
            Page2 = new NavigationPage(new Page2());

            navi.Navi = MainPage.Navigation;
            navi.myPage = MainPage;
        }

        public static Page LoginPage { get; private set; }

        public static Page MainPage { get; private set; }

        public static Page Page2 { get; private set; }
    }
}