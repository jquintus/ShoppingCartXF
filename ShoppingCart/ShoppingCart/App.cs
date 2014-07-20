using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using Xamarin.Forms;

namespace ShoppingCart
{
    public static class App
    {
        public static WelcomeViewModel WelcomeViewModel { get; set; }
        public static LoginViewModel LoginViewModel { get; set; }

        static App()
        {
            ILoginService login = new LoginService();
            NavigationService navi = new NavigationService();

            WelcomeViewModel = new WelcomeViewModel(navi);
            LoginViewModel  = new LoginViewModel(login, navi);

            WelcomePage = new NavigationPage(new WelcomePage());
            LoginPage = new NavigationPage(new LoginPage());
            Page2 = new NavigationPage(new Page2());

            navi.Navi = WelcomePage.Navigation;
            navi.myPage = WelcomePage;
        }

        public static Page LoginPage { get; private set; }

        public static Page WelcomePage { get; private set; }

        public static Page Page2 { get; private set; }
    }

}