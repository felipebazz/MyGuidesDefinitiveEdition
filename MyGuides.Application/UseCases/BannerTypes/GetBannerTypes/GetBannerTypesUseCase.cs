using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.BannerTypes.Queries;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.Context;
using Steam.Api.Interfaces;

namespace MyGuides.Application.UseCases.BannerTypes.GetBannerTypes
{
    public class GetBannerTypesUseCase : UseCase<IEnumerable<BannerTypeResult>>, IGetBannerTypesUseCase
    {
        public GetBannerTypesUseCase(IMediator mediator, INotificationService notificationContext)
            : base(mediator, notificationContext)
        {
        }

        protected async override Task<IEnumerable<BannerTypeResult>> OnExecuteAsync(CancellationToken cancellationToken)
                => await _mediator.Send(new GetBannerTypesQuery(), cancellationToken);
    }
}
