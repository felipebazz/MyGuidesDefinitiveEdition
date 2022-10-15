using MyGuides.Domain.Entities.Achievements;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Achievements
{
    public interface IAchievementRepository : IRepository<Achievement, Guid>
    {
    }
}
