using AutoMapper;
using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;
using MyGuides.Utils;
using Steam.Api.Interfaces;

namespace MyGuides.Application.UseCases.Games
{
    public class AddGameFromSteamStoreUseCase : TransactionalUseCase<AddGameRequest, GameResult>, IAddGameFromSteamStoreUseCase
    {
        private readonly ISteamUserStats _steamApi;

        public AddGameFromSteamStoreUseCase(IMediator mediator, IUnitOfWork unitOfWork, INotificationService notificationService, ISteamUserStats steamApi) 
            : base(mediator, unitOfWork, notificationService)
        {
            _steamApi = steamApi;
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

                var result = await _steamApi.GetSchemaForGameAsync("", request.StoreId);

                if (result is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                result.Game.AppId = request.StoreId;

                //montar o command e enviar para o handler

                return default;
            }
            catch(Exception ex)
            {
                _notificationService.AddNotification(ex);
                return default;
            }
        }
    }
}
