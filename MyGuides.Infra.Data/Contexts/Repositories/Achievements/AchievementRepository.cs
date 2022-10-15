using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Achievements
{
    public class AchievementRepository : Repository<Achievement, Guid>, IAchievementRepository
    {
        public AchievementRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
