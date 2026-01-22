using System;
using System.Collections.Concurrent;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace RGD.Core.ObjectsLoading
{
    public class ObjectsLoadingSystem : IObjectsLoadingSystem, IDisposable
    {
        private ConcurrentDictionary<string, AsyncOperationHandle> _cache = new();

        public T? LoadObject<T>(string address, bool autoRelease = false) where T : Object
        {
            ValidateAddress(address);

            T? cachedResult = TryGetFromCache<T>(address);
            if (cachedResult != null)
            {
                return cachedResult;
            }

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);

            try
            {
                return ProcessSyncLoad(address, handle, autoRelease);
            }
            catch (Exception ex)
            {
                throw new Exception($"ObjectsLoadingSystem: Failed to load object at address '{address}'", ex);
                return null;
            }
        }
        
        private T? TryGetFromCache<T>(string address) where T : Object
        {
            if (_cache.TryGetValue(address, out AsyncOperationHandle cachedHandle) &&
                cachedHandle.IsDone && cachedHandle.Status == AsyncOperationStatus.Succeeded)
            {
                return cachedHandle.Result as T;
            }

            return null;
        }
        
        private void ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address cannot be null or empty", nameof(address));
            }
        }
        
        private T? ProcessSyncLoad<T>(string address, AsyncOperationHandle<T> handle, bool autoRelease) where T : Object
        {
            handle.WaitForCompletion();

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                if (!autoRelease)
                {
                    _cache.TryAdd(address, handle);
                }

                T result = handle.Result;

                if (autoRelease && handle.IsValid())
                {
                    Addressables.Release(handle);
                }

                return result;
            }

            return null;
        }
        
        public void Dispose()
        {
            _cache.Clear();
            _cache = null;
        }
    }
}
