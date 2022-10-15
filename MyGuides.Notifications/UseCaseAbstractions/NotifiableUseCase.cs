using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Notifications.UseCaseAbstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase
    {
        protected readonly INotificationContext _notificationContext;

        protected NotifiableUseCase(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase<TResult> : NotifiableUseCase, INotifiableUseCase
    {
        public NotifiableUseCase(INotificationContext notificationContext)
            : base(notificationContext)
        {
        }

        public virtual async Task<RequestResult<TResult>> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await OnExecuteAsync(cancellationToken);
                return new RequestResult<TResult>
                {
                    Data = result,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification(ex);
            }

            return default;
        }

        protected abstract Task<TResult> OnExecuteAsync(CancellationToken cancellationToken);
    }

    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase<TRequest, TResult> : NotifiableUseCase, INotifiableUseCase
    {
        public NotifiableUseCase(INotificationContext notificationContext)
            : base(notificationContext)
        {
        }

        public virtual async Task<RequestResult<TResult>> ExecuteAsync(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await OnExecuteAsync(request, cancellationToken);
                return new RequestResult<TResult>
                {
                    Data = result,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification(ex);
            }

            return default;
        }

        protected abstract Task<TResult> OnExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
