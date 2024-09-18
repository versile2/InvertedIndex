using System.Collections.Concurrent;
using Web.DAL.Interfaces;

namespace Web.Tests.Helpers
{ // can use as an implementation of ILocalStorageService to test methods that use it
    public class InMemoryLocalStorageService : ILocalStorageService
    {
        private readonly ConcurrentDictionary<string, object> _storage = new ConcurrentDictionary<string, object>();

        public ValueTask<bool> ContainKeyAsync(string key)
        {
            return new ValueTask<bool>(_storage.ContainsKey(key));
        }

        public ValueTask<T> GetItemAsync<T>(string key)
        {
            if (_storage.TryGetValue(key, out var value))
            {
                if (value is T typedValue)
                {
                    return new ValueTask<T>(typedValue);
                }
                try
                {
                    // Attempt to convert the value to type T
                    return new ValueTask<T>((T)Convert.ChangeType(value, typeof(T)));
                }
                catch (InvalidCastException)
                {
                    throw new InvalidOperationException($"Unable to cast object of type {value.GetType()} to type {typeof(T)}");
                }
            }
            return new ValueTask<T>(default(T));
        }

        public ValueTask SetItemAsync<T>(string key, T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            _storage[key] = value;
            return ValueTask.CompletedTask;
        }

        public ValueTask DeleteItemAsync(string key)
        {
            _storage.TryRemove(key, out _);
            return ValueTask.CompletedTask;
        }

        // Additional method for testing purposes
        public void Clear()
        {
            _storage.Clear();
        }
    }
}
