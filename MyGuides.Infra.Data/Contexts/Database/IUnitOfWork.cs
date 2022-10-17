namespace MyGuides.Infra.Data.Contexts.Database
{
    public interface IUnitOfWork
    {
        //Task<TResult> ExecuteInTransactionAsync<TResult>(Func<CancellationToken, Task<TResult>> taskAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken, Func<CancellationToken, Task> callbackOnSuccess = null);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
