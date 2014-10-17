using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace ShoppingCart.WinPhone.Views
{
    public class WinPhoneAboutPageRenderer : VisualElementRenderer<Xamarin.Forms.Page, Microsoft.Phone.Controls.PhoneApplicationPage>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(new WinPhoneAboutPage());
        }
    }
}