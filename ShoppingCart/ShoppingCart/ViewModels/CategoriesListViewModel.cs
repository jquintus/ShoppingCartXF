using GalaSoft.MvvmLight.Command;
using ShoppingCart.Async;
using ShoppingCart.Models;
using ShoppingCart.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCart.ViewModels
{
    public class CategoriesListViewModel : BaseViewModel
    {
        private readonly INavigationService _navi;
        private readonly IScanner _scanner;
        private readonly RelayCommand _searchCommand;
        private readonly IProductService _service;

        public CategoriesListViewModel(IProductService service, INavigationService navi, IScanner scanner)
        {
            _service = service;
            _navi = navi;
            _scanner = scanner;

            _searchCommand = new RelayCommand(Search, () => !string.IsNullOrWhiteSpace(SearchTerm));
            ScanCommand = new RelayCommand(async () =>
            {
                var result = await _scanner.Scan();

                SearchTerm = result.Text;
                Search();
            });

            Categories = new NotifyTaskCompletion<List<CategoryViewModel>>(GetCategories());
        }

        public NotifyTaskCompletion<List<CategoryViewModel>> Categories { get; private set; }

        public ICommand ScanCommand { get; private set; }

        public ICommand SearchCommand { get { return _searchCommand; } }

        public string SearchTerm
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                _searchCommand.RaiseCanExecuteChanged();
            }
        }

        private async Task<List<CategoryViewModel>> GetCategories()
        {
            var navigateToCategory = new RelayCommand<Category>(async cat =>
            {
                var items = (await _service.GetProductsForCategory(cat.Name))
                    .OrderByDescending(i => i.Rating)
                    .ToList();

                if (items != null && items.Any())
                {
                    var page = App.GetProductsListPage(items, cat.Name);
                    await _navi.PushAsync(page);
                }
                else
                {
                    await _navi.DisplayAlert("Error", "There are no items in the category " + cat);
                }
            });

            var names = await _service.GetCategories();
            return names.Select(n => new CategoryViewModel(n, navigateToCategory)).ToList();
        }

        private async void Search()
        {
            var items = (await _service.Search(SearchTerm))
                        .OrderByDescending(i => i.Rating)
                        .ToList();

            if (items != null && items.Any())
            {
                Page page = items.Count == 1
                     ? page = App.GetProductPage(items.First())
                     : page = App.GetProductsListPage(items, SearchTerm);

                await _navi.PushAsync(page);
                SearchTerm = string.Empty;
            }
            else
            {
                await _navi.DisplayAlert("Error", "No results for search " + SearchTerm);
            }
        }
    }
}