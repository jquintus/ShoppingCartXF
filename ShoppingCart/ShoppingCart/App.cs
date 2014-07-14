using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using Xamarin.Forms;

namespace ShoppingCart
{
    public static class App
    {
        public static MainViewModel MainViewModel;
        public static LoginViewModel LoginViewModel;

        static App()
        {
            ILoginService login = new LoginService();
            NavigationService navi = new NavigationService();

            MainViewModel = new MainViewModel(navi);
            LoginViewModel  = new LoginViewModel(login, navi);

            MainPage = new NavigationPage(new MainPage());
            LoginPage = new NavigationPage(new LoginPage());
            Page2 = new NavigationPage(new Page2());

            navi.Navi = MainPage.Navigation;
            navi.myPage = MainPage;
        }

        public static Page LoginPage { get; private set; }

        public static Page MainPage { get; private set; }

        public static Page Page2 { get; private set; }
    }

}