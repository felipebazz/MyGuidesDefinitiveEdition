using MyGuides.Domain.Abstractions.Entities;

namespace MyGuides.Domain.Abstractions.Repository
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
           where TEntity : Entity
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }

    public interface IRepository<TEntity, in TId> : IReadOnlyRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(TId id);

        void Delete(TEntity entity);

        Task DeleteAsync(TId id, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
