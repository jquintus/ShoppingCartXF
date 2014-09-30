using ShoppingCart.Views;
using System;
using Xamarin.Forms;

namespace ShoppingCart.Services
{
    public class PageFactory : IPageFactory
    {
        private readonly ILoginService _login;

        public PageFactory(ILoginService login)
        {
            _login = login;
        }

        public Page GetPage(Pages page)
        {
            switch (page)
            {
                case Pages.Login: return new LoginPage();
                case Pages.Welcome: return new WelcomePage();
                case Pages.Categories: return new CategoriesListPage();
                default: throw new ArgumentException(string.Format("Unknown page type {0}", page));
            }
        }

        public Page GetStartPage()
        {
            if (_login.IsLoggedIn())
            {
                return GetPage(Pages.Categories);
            }
            else
            {
                return GetPage(Pages.Welcome);
            }
        }
    }
}