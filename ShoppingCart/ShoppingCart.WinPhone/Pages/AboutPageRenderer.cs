using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace ShoppingCart.WinPhone.Pages
{
    public class AboutPageRenderer : VisualElementRenderer<Xamarin.Forms.Page, Microsoft.Phone.Controls.PhoneApplicationPage>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(new AboutPage());
        }
    }
}