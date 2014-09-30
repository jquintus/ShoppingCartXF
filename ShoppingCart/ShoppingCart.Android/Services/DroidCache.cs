using ShoppingCart.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Droid.Services
{
    public class FakeDroidCache : ICache
    {
        public async Task<T> GetObject<T>(string key)
        {
            await Task.FromResult(0);
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXX GETTING OBJECT {0}", key);

            return default(T);
        }

        public async Task InsertObject<T>(string key, T value)
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXX INSERTING OBJECT {0}", key);

            await Task.FromResult(0);
        }
    }
}