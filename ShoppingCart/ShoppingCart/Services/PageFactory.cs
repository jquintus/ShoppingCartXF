using ShoppingCart.Views;
using System;
using Xamarin.Forms;

namespace ShoppingCart.Services
{
    public class PageFactory : IPageFactory
    {
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
    }
}