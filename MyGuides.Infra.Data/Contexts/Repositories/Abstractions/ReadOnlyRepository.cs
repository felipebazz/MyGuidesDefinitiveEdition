using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Abstractions.Pagination;
using MyGuides.Domain.Abstractions.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Abstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public ReadOnlyRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate) => _dbSet.Any(predicate);

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
            => _dbSet.AnyAsync(predicate, cancellationToken);

        public virtual IEnumerable<TEntity> Get() => _dbSet.AsNoTracking().ToList();

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate).ToList();

        public virtual Task<List<TEntity>> GetAsync(CancellationToken cancellationToken, bool asTracking = default)
            => asTracking
                ? _dbSet.AsTracking().ToListAsync(cancellationToken)
                : _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public virtual Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsNoTracking() : _dbSet.AsNoTracking();

            return include is null
                ? query.Where(predicate).ToListAsync(cancellationToken)
                : include(query).Where(predicate).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntityDefinition> GetByTypeAsync<TEntityDefinition>(CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = false) 
            where TEntityDefinition : TEntity
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();

            return include is null
                ? await query.OfType<TEntityDefinition>().SingleOrDefaultAsync(cancellationToken)
                : await include(query).OfType<TEntityDefinition>().SingleOrDefaultAsync(cancellationToken);
        }

        public virtual Task<PagedResult<TEntity>> GetPagedAsync(PageParams pageParams, CancellationToken cancellationToken, Expression<Func<TEntity, bool>> predicate = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntity>.CreateAsync(query, pageParams, cancellationToken);
        }

        public virtual Task<PagedResult<TEntity>> GetPagedAsync(PageParams pageParams, CancellationToken cancellationToken, IEnumerable<Expression<Func<TEntity, bool>>> predicates = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();

            query = include is null ? query : include(query);

            foreach (var predicate in predicates)
                query.Where(predicate);

            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntity>.CreateAsync(query, pageParams, cancellationToken);
        }

        public virtual Task<PagedResult<TEntityDefinition>> GetPagedAsync<TEntityDefinition>(PageParams pageParams, CancellationToken cancellationToken, Expression<Func<TEntityDefinition, bool>> predicate = null, Func<IQueryable<TEntityDefinition>, IOrderedQueryable<TEntityDefinition>> orderBy = null, Func<IQueryable<TEntityDefinition>, IIncludableQueryable<TEntityDefinition, object>> include = default, bool asTracking = default) where TEntityDefinition : TEntity
        {
            var query = asTracking ? _dbSet.AsTracking().OfType<TEntityDefinition>() : _dbSet.AsNoTracking().OfType<TEntityDefinition>();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntityDefinition>.CreateAsync(query, pageParams, cancellationToken);
        }

        public virtual Task<PagedResult<TEntityDefinition>> GetPagedAsync<TEntityDefinition>(PageParams pageParams, CancellationToken cancellationToken, IEnumerable<Expression<Func<TEntityDefinition, bool>>> predicates = null, Func<IQueryable<TEntityDefinition>, IOrderedQueryable<TEntityDefinition>> orderBy = null, Func<IQueryable<TEntityDefinition>, IIncludableQueryable<TEntityDefinition, object>> include = default, bool asTracking = default) where TEntityDefinition : TEntity
        {
            var query = asTracking ? _dbSet.AsTracking().OfType<TEntityDefinition>() : _dbSet.AsNoTracking().OfType<TEntityDefinition>();

            query = include is null ? query : include(query);

            foreach (var predicate in predicates)
                query.Where(predicate);

            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntityDefinition>.CreateAsync(query, pageParams, cancellationToken);
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (include is null && asTracking) return _dbSet.AsTracking().SingleOrDefault(predicate);

            return include is null
                ? _dbSet.AsNoTracking().SingleOrDefault(predicate)
                : include(_dbSet).AsNoTracking().SingleOrDefault(predicate);
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (include is null && asTracking) return await _dbSet.AsTracking().SingleOrDefaultAsync(predicate, cancellationToken);

            return include is null
                ? await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate, cancellationToken)
                : await include(_dbSet).AsNoTracking().SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }

    public abstract class ReadOnlyRepository<TEntity, TId> : ReadOnlyRepository<TEntity>, IReadOnlyRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected ReadOnlyRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public virtual bool Any(TId id)
            => _dbSet.Any(x => x.Equals(x.Id));

        public virtual Task<bool> AnyAsync(TId id, CancellationToken cancellationToken)
            => _dbSet.AnyAsync(x => id.Equals(x.Id), cancellationToken);

        public virtual TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return _dbSet.Find(id);

            return include is null
                ? _dbSet.AsNoTracking().SingleOrDefault(x => id.Equals(x.Id))
                : include(_dbSet).AsNoTracking().SingleOrDefault(x => id.Equals(x.Id));
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return await _dbSet.FindAsync(new object[] { id }, cancellationToken);

            return include is null
                ? await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => id.Equals(x.Id), cancellationToken)
                : await include(_dbSet).AsNoTracking().SingleOrDefaultAsync(x => id.Equals(x.Id), cancellationToken);
        }

        public virtual async Task<TEntityType> GetByIdAsync<TEntityType>(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntityType>, IIncludableQueryable<TEntityType, object>> include = null, bool asTracking = default)
            where TEntityType : TEntity
        {
            if (Equals(id, default(Guid))) return default;

            return include is null
                ? await _dbSet.AsNoTracking().OfType<TEntityType>().SingleOrDefaultAsync(x => id.Equals(x.Id), cancellationToken)
                : await include(_dbSet.OfType<TEntityType>()).AsNoTracking().SingleOrDefaultAsync(x => id.Equals(x.Id), cancellationToken);
        }
    }
}
