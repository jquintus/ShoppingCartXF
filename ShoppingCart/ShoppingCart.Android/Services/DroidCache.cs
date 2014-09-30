using Akavache;
using ShoppingCart.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ShoppingCart.Droid.Services
{

    public class DroidCache : ICache
    {
        public DroidCache()
        {
            BlobCache.ApplicationName = "ShoppingCart.Droid";
        }

        public async Task<T> GetObject<T>(string key)
        {
            return await BlobCache.LocalMachine.GetObject<T>(key);
        }

        public async Task InsertObject<T>(string key, T value)
        {
            await BlobCache.LocalMachine.InsertObject(key, value);
        }
    }

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