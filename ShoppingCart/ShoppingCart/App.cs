using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingCart
{
    public static class App
    {
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
            CategoriesListViewModel = new CategoriesListViewModel(products, navi);
            ProductViewModel = new ProductViewModel(navi);
            ProductsListViewModel = new ProductsListViewModel(navi);

            // Pages
            WelcomePage = new NavigationPage(new WelcomePage());
            LoginPage = new NavigationPage(new LoginPage());
            Page2 = new NavigationPage(new Page2());
            CategoriesListPage = new NavigationPage(new CategoriesListPage());
            ProductPage = new NavigationPage(new ProductPage());
            ProductsListPage = new NavigationPage(new ProductsListPage());

            // Startup Page
            WelcomePage = CategoriesListPage;

            // Navi
            navi.Navi = WelcomePage.Navigation;
            navi.myPage = WelcomePage;
        }

        public static Page CategoriesListPage { get; set; }

        public static CategoriesListViewModel CategoriesListViewModel { get; set; }

        public static Page LoginPage { get; private set; }

        public static LoginViewModel LoginViewModel { get; set; }

        public static Page Page2 { get; private set; }

        public static Page ProductPage { get; private set; }

        public static Page ProductsListPage { get; private set; }

        public static ProductsListViewModel ProductsListViewModel { get; set; }

        public static ProductViewModel ProductViewModel { get; set; }

        public static Page WelcomePage { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get; set; }

        public static Page GetProductPage(Item item)
        {
            ProductViewModel.Product = item;
            return new NavigationPage(new ProductPage());
        }

        public static Page GetProductsListPage(List<Item> items, string title)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "Products";

            ProductsListViewModel.Products = items;
            ProductsListViewModel.Title = title;
            return new NavigationPage(new ProductsListPage());
        }
    }
}