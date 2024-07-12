using Microsoft.Extensions.Caching.Memory;
using SerhanApp.Core.Entities;

namespace SerhanApp.Core.Caching
{
    public class InMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
    
        public TEntity GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            string cacheKey = $"{typeof(TEntity)}-{id}";

            var entity = _memoryCache.Get<TEntity>(cacheKey);

            return entity;
        }

        public bool IsSet(string cacheKey)
        {
            var entity = _memoryCache.Get(cacheKey);

            if (entity != null)
                return true;
            else
                return false;
        }

        public void Set<TEntity>(TEntity entity, int cacheTimeAsMinutes = 60) where TEntity : BaseEntity
        {
            string cacheKey = $"{typeof(TEntity)}-{entity.Id}";

            if (IsSet(cacheKey))
            {
                RemoveByKey(cacheKey);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(cacheTimeAsMinutes));
                _memoryCache.Set(cacheKey, entity, cacheEntryOptions);
            }

        }
        public void RemoveById<TEntity>(int id) where TEntity : BaseEntity
        {
            string cacheKey = $"{typeof(TEntity)}-{id}";

            _memoryCache.Remove(cacheKey);
        }

        public void RemoveByKey(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
} 
