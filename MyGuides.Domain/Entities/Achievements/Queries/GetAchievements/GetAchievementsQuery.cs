using MediatR;
using MyGuides.Domain.Entities.Achievements.Results;

namespace MyGuides.Domain.Entities.Achievements.Queries.GetAchievements
{
    public class GetAchievementsQuery : IRequest<IEnumerable<AchievementResult>>
    {
        public Guid GameId;

        public GetAchievementsQuery(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
