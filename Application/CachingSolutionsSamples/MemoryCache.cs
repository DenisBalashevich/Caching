using System.Collections.Generic;
using System.Runtime.Caching;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public class MemoryCache<T> : ICache<T>
    {
        //ObjectCache cache = MemoryCache.Default;
        //string prefix = "Cache_Categories";

        ////public ICache<T> Get(string forUser)
        ////{
        ////    return (ICache<T>)cache.Get(prefix + forUser);
        ////}

        //public void Set(string key, T value)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Set(string forUser, IEnumerable<T> categories)
        //{
        //    cache.Set(prefix + forUser, categories, ObjectCache.InfiniteAbsoluteExpiration);
        //}

        //public T ICache<T>.Get(string key)
        //{
        //    return (ICache<T>)cache.Get(prefix + key);
        //}

        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly string _prefix;

        public MemoryCache(string prefix)
        {
            _prefix = prefix;
        }

        public T Get(string key)
        {
            var fromCache = _cache.Get(_prefix + key);
            if (fromCache == null)
            {
                return default(T);
            }

            return (T)fromCache;
        }

        public void Set(string key, T value)
        {
            _cache.Set(_prefix + key, value, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
