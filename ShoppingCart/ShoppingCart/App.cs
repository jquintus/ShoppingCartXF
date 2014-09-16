using Autofac;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using ShoppingCart.Views;
using System;
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
            StartupPage = WelcomePage;
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




        public static Page GetMainPage()
        {
            var button = new Button
            {
                Text = "Click me",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var boxView = new BoxView
            {
                BackgroundColor = Color.Green
            };

            var rootLayout = new AbsoluteLayout
            {
                Children = { button, boxView }
            };

            AbsoluteLayout.SetLayoutBounds(rootLayout.Children[0],
                new Rectangle(20, 20, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(rootLayout.Children[1],
                new Rectangle(20, 80, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            int iClicks = 0;

            var eAndN = new Tuple<Easing, string>[] {
                new Tuple<Easing, string> (Easing.BounceIn, "BounceIn"),
                new Tuple<Easing, string> (Easing.BounceOut, "BounceOut"),
                new Tuple<Easing, string> (Easing.CubicIn, "CubicInOut"),
                new Tuple<Easing, string> (Easing.CubicOut, "CubicOut"),
                new Tuple<Easing, string> (Easing.Linear, "Linear"),
                new Tuple<Easing, string> (Easing.SinIn, "SinIn"),
                new Tuple<Easing, string> (Easing.SinInOut, "SinInOut"),
                new Tuple<Easing, string> (Easing.SinOut, "SinOut"),
                new Tuple<Easing, string> (Easing.SpringIn, "SpringIn"),
                new Tuple<Easing, string> (Easing.SpringOut, "SpringOut"),
                new Tuple<Easing, string> (new Easing(Math.Sin), "Custom")
            };

            button.Clicked += async (object sender, EventArgs e) =>
            {
                var newPos = new Rectangle(240, 80, 20, 20);

                var eAndName = eAndN[iClicks];
                var easing = eAndName.Item1;
                button.Text = eAndName.Item2;
                //boxView.LayoutTo(newPos, 2500, easing);
                
                await boxView.ScaleTo(2, 250, easing);
                await boxView.ScaleTo(1, 250, easing);
                iClicks++;
                iClicks %= eAndN.Length;
            };

            var cp = new ContentPage
            {
                Content = rootLayout,
                BackgroundColor = Color.White,
            };

            return cp;
        }

    }
}