using Microsoft.EntityFrameworkCore.Query;
using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Abstractions.Pagination;
using System.Linq.Expressions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Abstractions
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : Entity
    {
        bool Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        IEnumerable<TEntity> Get();

        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken, bool asTracking = default);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        Task<TEntityDefinition> GetByTypeAsync<TEntityDefinition>(CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
            where TEntityDefinition : TEntity;

        Task<PagedResult<TEntity>> GetPagedAsync(PageParams pageParams, CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default);

        Task<PagedResult<TEntity>> GetPagedAsync(PageParams pageParams, CancellationToken cancellationToken,
            IEnumerable<Expression<Func<TEntity, bool>>> predicates = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default);

        Task<PagedResult<TEntityDefinition>> GetPagedAsync<TEntityDefinition>(PageParams pageParams, CancellationToken cancellationToken,
            Expression<Func<TEntityDefinition, bool>> predicate = default,
            Func<IQueryable<TEntityDefinition>, IOrderedQueryable<TEntityDefinition>> orderBy = default,
            Func<IQueryable<TEntityDefinition>, IIncludableQueryable<TEntityDefinition, object>> include = default,
            bool asTracking = default)
            where TEntityDefinition : TEntity;

        Task<PagedResult<TEntityDefinition>> GetPagedAsync<TEntityDefinition>(PageParams pageParams, CancellationToken cancellationToken,
            IEnumerable<Expression<Func<TEntityDefinition, bool>>> predicates = default,
            Func<IQueryable<TEntityDefinition>, IOrderedQueryable<TEntityDefinition>> orderBy = default,
            Func<IQueryable<TEntityDefinition>, IIncludableQueryable<TEntityDefinition, object>> include = default,
            bool asTracking = default)
            where TEntityDefinition : TEntity;
        
    }

    public interface IReadOnlyRepository<TEntity, in TId> : IReadOnlyRepository<TEntity>
        where TEntity : Entity<TId>
        where TId : struct
    {
        bool Any(TId id);
        Task<bool> AnyAsync(TId id, CancellationToken cancellationToken);

        TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        Task<TEntityType> GetByIdAsync<TEntityType>(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntityType>, IIncludableQueryable<TEntityType, object>> include = default, bool asTracking = default) where TEntityType : TEntity;
    }
}
