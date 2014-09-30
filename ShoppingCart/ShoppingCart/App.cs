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

        public static Page GetProductPage(Product product)
        {
            var productViewModel = new ProductViewModel(product);

            ProductViewModel = productViewModel;
            return new ProductPage();
        }

        public static Page GetProductsListPage(List<Product> products, string title)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "Products";

            ProductsListViewModel.Products = products.Select(p => new ProductViewModel(p)).ToList();
            ProductsListViewModel.Title = title;
            return new ProductsListPage();
        }

        public static void Init(AppSetup appSetup)
        {
            _container = appSetup.CreateContainer();

            NaviService = Resolve<INavigationService>() as NavigationService;
            AccentColor = Resolve<IThemer>().AccentColor;
            var pageFactory = Resolve<IPageFactory>();

            StartupPage = pageFactory.GetPage(Pages.Welcome);
        }

        #region View Models

        public static CategoriesListViewModel CategoriesListViewModel { get { return Resolve<CategoriesListViewModel>(); } }

        public static LoginViewModel LoginViewModel { get { return Resolve<LoginViewModel>(); } }

        public static ProductsListViewModel ProductsListViewModel { get { return Resolve<ProductsListViewModel>(); } }

        public static ProductViewModel ProductViewModel { get; private set; }

        public static WelcomeViewModel WelcomeViewModel { get { return Resolve<WelcomeViewModel>(); } }

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