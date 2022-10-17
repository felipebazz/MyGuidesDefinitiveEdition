using MyGuides.Notifications.Result;

namespace MyGuides.Notifications.UseCaseAbstractions
{
    public interface INotifiableUseCase<TRequest, TResult>
    {
        Task<RequestResult<TResult>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }

    public interface INotifiableUseCase<TResult>
    {
        Task<RequestResult<TResult>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
