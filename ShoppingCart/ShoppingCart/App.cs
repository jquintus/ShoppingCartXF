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

        public static ProductListViewModel ProductListViewModel { get; set; }

        static App()
        {
            // Services
            ILoginService login = new LoginService();
            IProductLoader loader = new ProductLoader();
            IProductService products = new ProductService(loader);
            NavigationService navi = new NavigationService();

            // View Models
            WelcomeViewModel = new WelcomeViewModel(navi);
            LoginViewModel = new LoginViewModel(login, navi);
            ProductListViewModel = new ProductListViewModel(products);

            // Pages
            WelcomePage = new NavigationPage(new WelcomePage());
            LoginPage = new NavigationPage(new LoginPage());
            Page2 = new NavigationPage(new Page2());
            ProductListPage = new NavigationPage(new ProductListPage());
            WelcomePage = ProductListPage;

            // Navi
            navi.Navi = WelcomePage.Navigation;
            navi.myPage = WelcomePage;
        }

        public static Page LoginPage { get; private set; }

        public static Page WelcomePage { get; private set; }

        public static Page Page2 { get; private set; }

        public static Page ProductListPage { get; set; }
    }

}