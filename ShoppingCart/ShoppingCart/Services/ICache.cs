using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public interface ICache
    {
        Task<T> GetObject<T>(string key);

        Task InsertObject<T>(string key, T value);
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
            _logger.Info("XXXXXXXXXXXXXXXXXXXXXXXXX GETTING OBJECT {0}", key);

            return default(T);
        }

        public async Task InsertObject<T>(string key, T value)
        {
            _logger.Info("XXXXXXXXXXXXXXXXXXXXXXXXX INSERTING OBJECT {0}", key);

            await Task.FromResult(0);
        }
    }
}
