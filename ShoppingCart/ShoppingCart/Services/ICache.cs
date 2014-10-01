using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICache
    {
        Task<T> GetObject<T>(string key);

        Task InsertObject<T>(string key, T value);

        Task RemoveObject(string key);
    }

    public class MockCache : ICache
    {
        private readonly ILogger _logger;

        public MockCache(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<T> GetObject<T>(string key)
        {
            await Task.FromResult(0);
            _logger.Info("GETTING OBJECT {0}", key);

            return default(T);
        }

        public async Task InsertObject<T>(string key, T value)
        {
            _logger.Info("INSERTING OBJECT {0}", key);

            await Task.FromResult(0);
        }

        public async Task RemoveObject(string key)
        {
            _logger.Info("REMOVING OBJECT {0}", key);
            await Task.FromResult(0);
        }
    }
}