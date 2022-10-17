using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Notifications.UseCaseAbstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase
    {
        protected readonly INotificationService _notificationService;

        protected NotifiableUseCase(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase<TResult> : NotifiableUseCase, INotifiableUseCase<TResult>
    {
        public NotifiableUseCase(INotificationService notificationService)
            : base(notificationService)
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
                _notificationService.AddNotification(ex);
            }

            return default;
        }

        protected abstract Task<TResult> OnExecuteAsync(CancellationToken cancellationToken);
    }

    [ExcludeFromCodeCoverage]
    public abstract class NotifiableUseCase<TRequest, TResult> : NotifiableUseCase, INotifiableUseCase<TRequest, TResult>
    {
        public NotifiableUseCase(INotificationService notificationService)
            : base(notificationService)
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
                _notificationService.AddNotification(ex);
            }

            return default;
        }

        protected abstract Task<TResult> OnExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
