using Android.App;
using Android.OS;
using Android.Util;
using Xamarin.Forms.Platform.Android;

namespace ShoppingCart.Droid
{
    [Activity(Label = "ShoppingCart", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            var page = App.FirstPage;
            if (page == null)
            {
                Log.Error("ShoppingCart", "WelcomePage is null");
            }
            SetPage(page);
        }
    }
}