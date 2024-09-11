using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Web.DAL.Interfaces;

namespace Web.DAL.Services
{
    public class LocalStorageService(ProtectedLocalStorage localStorage) : ILocalStorageService
    {
        private readonly ProtectedLocalStorage? _localStorage = localStorage; // nullable for unit tests

        public async ValueTask<bool> ContainKeyAsync(string key)
        {
            if (_localStorage == null)
                return false;
            return (await _localStorage.GetAsync<object>(key)).Success;
        }

        public async ValueTask<ProtectedBrowserStorageResult<T>> GetItemAsync<T>(string key)
        {
            if (_localStorage == null)
                return default;
            try
            {
                return await _localStorage.GetAsync<T>(key);
            }
            catch (CryptographicException)
            {
                // corrupted result, clear it
                await _localStorage.DeleteAsync(key);
            }
            return await _localStorage.GetAsync<T>(key);
        }

        public async ValueTask SetItemAsync<T>(string key, T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (_localStorage == null)
                return;
            else
                await _localStorage.SetAsync(key, value);
        }
        public async ValueTask DeleteItemAsync(string key)
        {
            if (_localStorage == null)
                return;
            await _localStorage.DeleteAsync(key);
        }
    }
}
