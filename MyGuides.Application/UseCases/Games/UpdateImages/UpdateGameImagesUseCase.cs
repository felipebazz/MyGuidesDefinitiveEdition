using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Games.Commands.UpdateImages;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;
using Steam.Api.Clients.StoreApi;

namespace MyGuides.Application.UseCases.Games.UpdateImages
{
    public class UpdateGameImagesUseCase : TransactionalUseCase<UpdateImagesRequest, GameResult>, IUpdateGameImagesUseCase
    {
        private readonly ISteamStoreApiWebClient _storeApiClient;

        public UpdateGameImagesUseCase(
            IMediator mediator,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            ISteamStoreApiWebClient storeApiClient)
            : base(mediator, unitOfWork, notificationService)
        {
            _storeApiClient = storeApiClient;
        }

        protected override async Task<GameResult> OnExecuteAsync(UpdateImagesRequest request, CancellationToken cancellationToken)
        {
            if (request.StoreId is null)
            {
                _notificationService.AddNotification(ApplicationValidationMessages.UpdateGameImagesUseCase_Request_Empty);
                return default;
            }

            var result = await _storeApiClient.GetAppDetailsFromStore(request.StoreId);

            if (result is null)
            {
                _notificationService.AddNotification(ApplicationValidationMessages.UpdateGameImagesUseCase_Result_Empty);
                return default;
            }

            var command = new UpdateImagesCommand()
            {
                GameId = request.GameId,
                Image = result.HeaderImage,
                BackgroundImage = result.BackgroundRaw
            };

            return await _mediator.Send(command, cancellationToken);
        }
    }
}
