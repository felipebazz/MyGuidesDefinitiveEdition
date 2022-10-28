namespace MyGuides.Infra.Data.Contexts.Database
{
    public interface IUnitOfWork
    {
         Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
