using MyGuides.Domain.Entities.Achievements.Queries.GetAchievements;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Achievements.GetAchievements
{
    public interface IGetAchievementsUseCase : INotifiableUseCase<GetAchievementsQuery, IEnumerable<AchievementResult>>
    {
    }
}
