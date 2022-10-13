using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Abstractions.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Contexts.Repositories.Abstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly DbContext _dbContext;

        protected Repository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity is null) return default;
            if (!entity.Valid) return entity;

            var entityEntry = _dbSet.Add(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return default;
            if (!entity.Valid) return entity;

            var entityEntry = await _dbSet.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is null) return;

            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return;
            await Task.Run(() => Delete(entity), cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            if (!entity.Valid) return;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (!entity.Valid) return;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class Repository<TEntity, TId> : ReadOnlyRepository<TEntity, TId>, IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly DbContext _dbContext;

        protected Repository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity is null) return default;
            if (!entity.Valid) return entity;
            if (Any(entity.Id)) return entity;
            var entityEntry = _dbSet.Add(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return default;
            if (!entity.Valid) return entity;
            if (await AnyAsync(entity.Id, cancellationToken)) return entity;
            var entityEntry = await _dbSet.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }

        public virtual void Delete(TId id)
        {
            if (Equals(id, default(TId)) is true) return;
            var entity = GetById(id, asTracking: true);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null) return;
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, default(TId)) is true) return;
            var entity = await GetByIdAsync(id, cancellationToken, asTracking: true);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return;
            await Task.Run(() => Delete(entity), cancellationToken);
        }

        public void Update(TEntity entity)
        {
            if (!entity.Valid) return;
            if (Any(entity.Id) is false) return;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (!entity.Valid) return;
            if (await AnyAsync(entity.Id, cancellationToken) is false) return;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
