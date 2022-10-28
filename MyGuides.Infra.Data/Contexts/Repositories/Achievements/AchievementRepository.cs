using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Achievements.Repositories;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Achievements
{
    public class AchievementRepository : Repository<Achievement, Guid>, IAchievementRepository
    {
        public AchievementRepository(MyGuidesContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
