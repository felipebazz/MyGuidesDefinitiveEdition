using MediatR;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;
using MyGuides.Notifications.UseCaseAbstractions;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Application.Abstractions
{
    [ExcludeFromCodeCoverage]
    public abstract class UseCase<TResult> : NotifiableUseCase<TResult>
    {
        protected readonly IMediator _mediator;
        public UseCase(IMediator mediator, INotificationService notificationService) 
            : base(notificationService)
        {
            _mediator = mediator;
        }
    }

    public abstract class UseCase<TRequest, TResult> : NotifiableUseCase<TRequest, TResult>
    {
        protected readonly IMediator _mediator;
        protected UseCase(IMediator mediator, INotificationService notificationService) 
            : base(notificationService)
        {
            _mediator = mediator;
        }
    }
}
