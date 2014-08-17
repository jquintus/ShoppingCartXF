using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ShoppingCart
{
    public static class App
    {
        private static NavigationService NaviService;

        static App()
        {
            // Services
            ILoginService login = new LoginService();
            IProductLoader loader = new ProductLoader();
            IProductService products = new ProductService(loader);
            NaviService = new NavigationService();

            // View Models
            WelcomeViewModel = new WelcomeViewModel(NaviService);
            LoginViewModel = new LoginViewModel(login, NaviService);
            CategoriesListViewModel = new CategoriesListViewModel(products, NaviService);
            ProductsListViewModel = new ProductsListViewModel(NaviService);

            // Pages
            WelcomePage = new NavigationPage(new WelcomePage());
            LoginPage = new NavigationPage(new LoginPage());
            CategoriesListPage = new NavigationPage(new CategoriesListPage());

            // Startup Page
            WelcomePage = CategoriesListPage;

            // Navi
            NaviService.Navi = WelcomePage.Navigation;
            NaviService.myPage = WelcomePage;
        }

        public static Page CategoriesListPage { get; set; }

        public static CategoriesListViewModel CategoriesListViewModel { get; set; }

        public static Page LoginPage { get; private set; }

        public static LoginViewModel LoginViewModel { get; set; }

        public static ProductsListViewModel ProductsListViewModel { get; set; }

        public static ProductViewModel ProductViewModel { get; set; }

        public static Page WelcomePage { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get; set; }

        public static Page GetProductPage(ProductViewModel productViewModel)
        {
            ProductViewModel = productViewModel;
            return new NavigationPage(new ProductPage());
        }

        public static Page GetProductsListPage(List<Product> products, string title)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "Products";

            ProductsListViewModel.Products = products.Select(p => new ProductViewModel(NaviService, p)).ToList();
            ProductsListViewModel.Title = title;
            return new NavigationPage(new ProductsListPage());
        }
    }
}