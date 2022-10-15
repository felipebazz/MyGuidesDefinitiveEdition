using MyGuides.Domain.Abstractions.Repository;

namespace MyGuides.Domain.Entities.Achievements.Repositories
{
    public interface IAchievementRepository : IRepository<Achievement, Guid>
    {
    }
}
