using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Contexts.Database
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyGuidesContext _dbContext;

        public UnitOfWork(MyGuidesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);
        
    }
}
