using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Web.DAL.Interfaces
{
    public interface ILocalStorageService
    {
        ValueTask<bool> ContainKeyAsync(string key);

        ValueTask<ProtectedBrowserStorageResult<T>> GetItemAsync<T>(string key);

        ValueTask SetItemAsync<T>(string key, T value);

        ValueTask DeleteItemAsync(string key);
    }
}
