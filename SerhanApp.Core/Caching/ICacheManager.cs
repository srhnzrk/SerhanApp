using SerhanApp.Core.Entities;

namespace SerhanApp.Core.Caching
{
    public interface ICacheManager
    {
        TEntity GetById<TEntity>(int id) where TEntity : BaseEntity;

        bool IsSet(string cacheKey);

        void Set<TEntity>(TEntity entity, int cacheTimeAsMinutes = 60) where TEntity : BaseEntity;

        void RemoveById<TEntity>(int id) where TEntity : BaseEntity;

        void RemoveByKey(string cacheKey);
    }
}