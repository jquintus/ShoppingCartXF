using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface IScanner
    {
        Task<ScanResult> Scan();
    }

    public class ScanResult
    {
        public string Text { get; set; }
    }
}