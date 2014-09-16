using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private readonly Category _category;

        public CategoryViewModel(Category category)
        {
            _category = category;

            NavigateToCategory = new Command(() => MessagingCenter.Send(category, Messages.NavigateTo));

            Name = _category.Name;

            if (_category.Count == 1)
            {
                Count = "1 item";
            }
            else if (_category.Count > 1)
            {
                Count = string.Format("{0} items", _category.Count);
            }
            else
            {
                Count = "No items";
            }
        }

        public Category Category { get { return _category; } }

        public string Count { get; private set; }

        public string Name { get; private set; }

        public ICommand NavigateToCategory { get; private set; }
    }
}