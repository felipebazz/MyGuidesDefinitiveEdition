using MediatR;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Queries
{
    public class GetGamesQuery : IRequest<IEnumerable<GameResult>>
    {
    }
}
