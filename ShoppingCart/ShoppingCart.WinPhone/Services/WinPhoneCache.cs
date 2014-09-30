using ShoppingCart.Services;
using System;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.WinPhone.Services
{
    public class WinPhoneCache : ICache
    {
        private readonly IsolatedStorageSettings _settings;

        public WinPhoneCache()
        {
            _settings = IsolatedStorageSettings.ApplicationSettings;
        }

        public Task<T> GetObject<T>(string key)
        {
            if (!_settings.Contains(key))
            {
                return Task.FromResult((T)_settings[key]);
            }
            else
            {
                return Task.FromResult(default(T));
            }
        }

        public Task InsertObject<T>(string key, T value)
        {
            if (!_settings.Contains(key))
            {
                _settings.Add(key, value);
            }
            else
            {
                _settings[key] = value;
            }
            _settings.Save();

            return Task.FromResult(0);
        }
    }
}