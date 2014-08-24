using Java.Lang;
using ShoppingCart.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

namespace ShoppingCart.Droid.Services
{
    public class DroidScanner : IScanner
    {
        public async Task<ScanResult> Scan()
        {
            var context = Forms.Context;
            var scanner = new MobileBarcodeScanner(context)
            {
                UseCustomOverlay = false,
                BottomText = "Scanning will happen automatically",
                TopText = "Hold your camera about \n6 inches away from the barcode",
            };

            var result = await scanner.Scan();

            return new ScanResult
            {
                Text = result.Text,
            };
        }
    }
}