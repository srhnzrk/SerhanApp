using SerhanApp.Core.Entities;

namespace SerhanApp.Data
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        List<TEntity> GetAllEntities();

        TEntity GetEntityById(int entityId);

        void InsertEntity(TEntity entity);

        void UpdateEntity(TEntity entity);

        void RemoveEntity(TEntity entity);

        void RemoveEntityById(int entityId);
    }
}