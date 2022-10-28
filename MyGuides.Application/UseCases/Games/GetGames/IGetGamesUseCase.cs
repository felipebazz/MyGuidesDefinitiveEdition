using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Games.GetGames
{
    public interface IGetGamesUseCase : INotifiableUseCase<IEnumerable<GameResult>>
    {
    }
}
