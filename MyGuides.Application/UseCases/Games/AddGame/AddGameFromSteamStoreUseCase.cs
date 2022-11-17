using AutoMapper;
using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Commands;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;
using MyGuides.Utils;
using Steam.Api.Clients.StoreApi;
using Steam.Api.Clients.WebApi;

namespace MyGuides.Application.UseCases.Games.AddGame
{
    public class AddGameFromSteamStoreUseCase : TransactionalUseCase<AddGameRequest, GameResult>, IAddGameFromSteamStoreUseCase
    {
        private readonly ISteamWebApiClient _steamApi;
        private readonly IStoreApiClient _storeApiClient;
        private readonly IMapper _mapper;

        public AddGameFromSteamStoreUseCase(
            IMediator mediator, 
            IUnitOfWork unitOfWork, 
            INotificationService notificationService, 
            ISteamWebApiClient steamApi,
            IStoreApiClient storeApiClient,
            IMapper mapper)
            : base(mediator, unitOfWork, notificationService)
        {
            _storeApiClient = storeApiClient;
            _steamApi = steamApi;
            _mapper = mapper;
        }

        protected override async Task<GameResult> OnExecuteAsync(AddGameRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.StoreId is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                request.StoreId = AppIdConverter.GetAppId(request.StoreId);

                var result = await _steamApi.GetSchemaForGameAsync("AF458C11CC9AAF3E010199B1E61849DE", request.StoreId);

                if (result is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                result.Game.AppId = request.StoreId;

                var game = _mapper.Map<Game>(result.Game);

                if (game is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                var achievements = _mapper.Map<List<Achievement>>(result.Game.AvailableGameStats.Achievements);

                if (achievements is null || achievements.Count == 0)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                var command = new AddGameCommand(game.Name, game.Version, game.AppId, achievements);

                return await _mediator.Send(command, cancellationToken);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(ex);
                return default;
            }
        }
    }
}
