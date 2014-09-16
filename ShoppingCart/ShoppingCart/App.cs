using Autofac;
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
        private static IContainer _container;
        private static NavigationService NaviService;
        private static NavigationPage _firstPage;

        public static void Init(AppSetup appSetup)
        {
            _container = appSetup.CreateContainer();

            NaviService = _container.Resolve<INavigationService>() as NavigationService;
            AccentColor = _container.Resolve<IThemer>().AccentColor;

            WelcomePage = new WelcomePage();
            LoginPage = new LoginPage();
            CategoriesListPage = new CategoriesListPage();

            // Startup Page
            StartupPage = CategoriesListPage;
        }

        #region View Models

        public static CategoriesListViewModel CategoriesListViewModel { get { return _container.Resolve<CategoriesListViewModel>(); } }

        public static LoginViewModel LoginViewModel { get { return _container.Resolve<LoginViewModel>(); } }

        public static ProductsListViewModel ProductsListViewModel { get { return _container.Resolve<ProductsListViewModel>(); } }

        public static ProductViewModel ProductViewModel { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get { return _container.Resolve<WelcomeViewModel>(); } }

        #endregion

        #region Pages

        public static Page CategoriesListPage { get; set; }

        public static Page StartupPage
        {
            get { return _firstPage; }
            set
            {
                _firstPage = new NavigationPage(value);
                NaviService.Navi = StartupPage.Navigation;
                NaviService.myPage = StartupPage;
            }
        }

        public static Page LoginPage { get; private set; }

        public static Page WelcomePage { get; private set; }

        #endregion

        public static Color AccentColor { get; private set; }

        public static Page GetProductPage(Product product)
        {
            var vm = new ProductViewModel(product, ProductsListViewModel.NavigateToProduct);
            return GetProductPage(vm);
        }

        public static Page GetProductPage(ProductViewModel productViewModel)
        {
            ProductViewModel = productViewModel;
            return new ProductPage();
        }

        public static Page GetProductsListPage(List<Product> products, string title)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "Products";

            var cmd = ProductsListViewModel.NavigateToProduct;
            ProductsListViewModel.Products = products.Select(p => new ProductViewModel(p, cmd)).ToList();
            ProductsListViewModel.Title = title;
            return new ProductsListPage();
        }
    }
}