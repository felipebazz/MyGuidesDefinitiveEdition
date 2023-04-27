using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Games.Commands.AddGame;
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
        private readonly string _apiKey;
        private readonly IMapper _mapper;
        private readonly ISteamWebApiClient _steamApi;
        private readonly IConfiguration _configuration;
        private readonly ISteamStoreApiWebClient _steamStoreApi;

        public AddGameFromSteamStoreUseCase(
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            ISteamWebApiClient steamApi,
            IConfiguration configuration,
            ISteamStoreApiWebClient steamStoreApi,
            INotificationService notificationService)
            : base(mediator, unitOfWork, notificationService)
        {
            _mapper = mapper;
            _steamApi = steamApi;
            _steamStoreApi = steamStoreApi;
            _configuration = configuration;

            _apiKey = _configuration.GetSection(nameof(Settings)).Get<Settings>().ApiKey;
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

                var result = await _steamApi.GetSchemaForGameAsync(_apiKey, request.StoreId);
                var storeResult = await _steamStoreApi.GetAppDetailsFromStore(request.StoreId);

                if (result is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                result.Game.AppId = request.StoreId;

                var command = new AddGameCommand(
                    storeResult.Name ?? result.Game.GameName,
                    result.Game.GameVersion, 
                    result.Game.AppId, 
                    result.Game.AvailableGameStats.Achievements, 
                    storeResult.HeaderImage, 
                    storeResult.BackgroundRaw);

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
