using ShoppingCart.Services;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace ShoppingCart.WinPhone.Services
{
    public class WinPhoneScanner : IScanner
    {
        public async Task<ScanResult> Scan()
        {
            var scanner = new MobileBarcodeScanner(MainPage.DispatcherSingleton)
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