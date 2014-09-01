using Microsoft.Phone.Controls;

using Xamarin.Forms;

namespace ShoppingCart.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = ShoppingCart.App.StartupPage.ConvertPageToUIElement(this);
            DispatcherSingleton = this.Dispatcher;
        }

        public static System.Windows.Threading.Dispatcher DispatcherSingleton { get; private set; }
    }
}