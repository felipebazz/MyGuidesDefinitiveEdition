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
        {
            try
            {
                var result = await _steamApi.GetSchemaForGameAsync("29B79E492F3ED25D06DD4C3BC6C63E7B", "254700");

                if (result == null)
                {
                    return default;
                }
            }
            catch (Exception ex)
            {

            }


            return await _mediator.Send(new GetBannerTypesQuery(), cancellationToken);
        }
        //=> _mediator.Send(new GetBannerTypesQuery(), cancellationToken);
    }
}
