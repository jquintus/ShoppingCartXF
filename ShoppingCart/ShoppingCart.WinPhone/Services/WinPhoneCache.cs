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

        public async Task RemoveObject(string key)
        {
            await Task.Factory.StartNew(() =>
            {
                if (_settings.Contains(key))
                {
                    _settings.Remove(key);
                    _settings.Save();
                }
            });
        }

        public async Task<T> GetObject<T>(string key)
        {
            return await Task.Factory.StartNew<T>(() =>
            {
                if (_settings.Contains(key))
                {
                    return (T)_settings[key];
                }
                else
                {
                    return default(T);
                }
            });
        }

        public async Task InsertObject<T>(string key, T value)
        {
            await Task.Factory.StartNew(() =>
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
            });
        }
    }
}