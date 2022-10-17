using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.BannerTypes.Queries;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases
{
    public class GetBannerTypesUseCase : UseCase<IEnumerable<BannerTypeResult>>, IGetBannerTypesUseCase
    {
        public GetBannerTypesUseCase(IMediator mediator, INotificationService notificationContext) 
            : base(mediator, notificationContext)
        {
        }

        protected override Task<IEnumerable<BannerTypeResult>> OnExecuteAsync(CancellationToken cancellationToken)
            => _mediator.Send(new GetBannerTypesQuery(), cancellationToken);
    }
}
