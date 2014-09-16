using ShoppingCart.Models;
using System.Windows.Input;

namespace ShoppingCart.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private readonly Category _category;

        public CategoryViewModel(Category category, ICommand navigateCommand)
        {
            _category = category;
            NavigateToCategory = navigateCommand;

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