using ShoppingCart.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

namespace ShoppingCart.Droid.Services
{
    public class DroidScanner : IScanner
    {
        private readonly ILogger _logger;

        public DroidScanner(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<ScanResult> Scan()
        {
            _logger.Info("Starting the barcode scanner.  Stand back.");

            var context = Forms.Context;
            var scanner = new MobileBarcodeScanner(context)
            {
                UseCustomOverlay = false,
                BottomText = "Scanning will happen automatically",
                TopText = "Hold your camera about \n6 inches away from the barcode",
            };

            try
            {
                var result = await scanner.Scan();

                return new ScanResult
                {
                    Text = result.Text,
                };
            }
            catch (System.Exception)
            {
                _logger.Info("User hit back");
                return new ScanResult
                {
                    Text = string.Empty,
                };
            }
        }
    }
}