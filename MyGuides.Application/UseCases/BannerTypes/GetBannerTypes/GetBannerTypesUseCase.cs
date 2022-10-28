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
        private readonly ISteamUserStats _steamApi;
        public GetBannerTypesUseCase(IMediator mediator, INotificationService notificationContext, ISteamUserStats steamApi)
            : base(mediator, notificationContext)
        {
            _steamApi = steamApi;
        }

        protected async override Task<IEnumerable<BannerTypeResult>> OnExecuteAsync(CancellationToken cancellationToken)
                => await _mediator.Send(new GetBannerTypesQuery(), cancellationToken);
    }
}
