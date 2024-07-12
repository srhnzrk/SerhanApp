using Microsoft.EntityFrameworkCore;
using SerhanApp.Core.Entities;

namespace SerhanApp.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private SerhanContext _context;

        private DbSet<TEntity> _entities;

        public GenericRepository(SerhanContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public List<TEntity> GetAllEntities()
        {
            return _entities.ToList();
        }

        public TEntity GetEntityById(int entityId)

        {
            var entity = _entities.FirstOrDefault(x => x.Id == entityId);
            return entity;
        }

        public void InsertEntity(TEntity entity)
        {
            if (entity != null)
            {
                if (entity is IFullAuditedEntity fullAuditedEntity)
                {
                    fullAuditedEntity.CreatedOnUtc = DateTime.UtcNow;
                }
                _entities.Add(entity);
                _context.SaveChanges();
            }
        }

        public void RemoveEntity(TEntity entity)
        {
            if (entity != null)
            {
                if (entity is ISoftDeletedEntity softDeletedEntity)
                {
                    softDeletedEntity.Deleted = true;
                }
                _context.SaveChanges();
            }
        }

        public void RemoveEntityById(int entityId)
        {
            if (entityId > 0)
            {
                var entity = _entities.FirstOrDefault(x => x.Id == entityId);
                this.RemoveEntity(entity);
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            if (entity != null)
            {
                if (entity is IFullAuditedEntity fullAuditedEntity)
                {
                    fullAuditedEntity.UpdatedOnUtc = DateTime.UtcNow;
                }
                _entities.Update(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<TEntity> Table
        {
            get
            {
                return _entities.AsQueryable();
            }
        }
    }
}