using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Games
{
    public interface IAddGameFromSteamStoreUseCase : INotifiableUseCase<AddGameRequest, GameResult>
    {
    }
}
