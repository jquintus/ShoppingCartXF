using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingCart.Services
{
    public class AppNavigation : ShoppingCart.Services.IAppNavigation
    {
        private readonly INavigationService _navi;

        public AppNavigation(INavigationService navi)
        {
            _navi = navi;
        }

        public async Task ShowProductList(List<Models.Product> items, string title, bool canShowSinglePage = false)
        {
            if (items != null && items.Any())
            {
                Page page;
                if (canShowSinglePage && items.Count == 1)
                {
                    page = App.GetProductPage(items.First());
                }
                else
                {
                    page = App.GetProductsListPage(items, title);
                }
                await _navi.PushAsync(page);
            }
            else
            {
                await _navi.DisplayAlert("Error", "There are no items to show for " + title);
            }
        }
    }
}