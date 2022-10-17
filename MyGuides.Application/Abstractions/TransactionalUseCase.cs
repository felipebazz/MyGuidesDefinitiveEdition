using MediatR;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Application.Abstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class TransactionalUseCase<TRequest, TResult> : UseCase<TRequest, TResult>
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected TransactionalUseCase(IMediator mediator, IUnitOfWork unitOfWork, INotificationService notificationService)
            : base(mediator, notificationService)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<RequestResult<TResult>> ExecuteAsync(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await OnExecuteAsync(request, cancellationToken);

                if (_notificationService.HasNotifications) return default;

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new RequestResult<TResult>
                {
                    Data = result,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(ex);           
            }

            return default;
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class TransactionalUseCase<TResult> : UseCase<TResult>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected TransactionalUseCase(IMediator mediator, IUnitOfWork unitOfWork, INotificationService notificationService) 
            : base(mediator, notificationService)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<RequestResult<TResult>> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await OnExecuteAsync(cancellationToken);

                if (_notificationService.HasNotifications) return default;

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new RequestResult<TResult>
                {
                    Data = result,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(ex);
            }

            return default;
        }

    }
}
