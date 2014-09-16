using Autofac;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace ShoppingCart
{
    public static class App
    {
        private static IContainer _container;
        private static NavigationPage _firstPage;
        private static NavigationService NaviService;

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

        public static void Init(AppSetup appSetup)
        {
            _container = appSetup.CreateContainer();

            NaviService = Resolve<INavigationService>() as NavigationService;
            AccentColor = Resolve<IThemer>().AccentColor;

            WelcomePage = new WelcomePage();
            LoginPage = new LoginPage();
            CategoriesListPage = new CategoriesListPage();

            // Startup Page
            StartupPage = WelcomePage;
        }

        #region View Models

        public static CategoriesListViewModel CategoriesListViewModel { get { return Resolve<CategoriesListViewModel>(); } }

        public static LoginViewModel LoginViewModel { get { return Resolve<LoginViewModel>(); } }

        public static ProductsListViewModel ProductsListViewModel { get { return Resolve<ProductsListViewModel>(); } }

        public static ProductViewModel ProductViewModel { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get { return Resolve<WelcomeViewModel>(); } }

        #endregion

        #region Pages

        public static Page CategoriesListPage { get; set; }

        public static Page LoginPage { get; private set; }

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

        public static Page WelcomePage { get; private set; }

        #endregion

        private static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error resolving type {0}:  {1}", typeof(T).FullName, ex);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}