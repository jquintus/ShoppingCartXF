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

        public Task Clear(string key)
        {
            if (_settings.Contains(key))
            {
                _settings.Remove(key);
                _settings.Save();
            }

            return Task.FromResult(0);
        }

        public Task<T> GetObject<T>(string key)
        {
            if (_settings.Contains(key))
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
            if (_settings.Contains(key))
            {
                _settings[key] = value;
            }
            else
            {
                _settings.Add(key, value);
            }
            _settings.Save();

            return Task.FromResult(0);
        }
    }
}