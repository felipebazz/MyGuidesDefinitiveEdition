using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Difficulties;
using MyGuides.Domain.Entities.Difficulties.Repository;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Difficulties
{
    public class DifficultyRepository : Repository<Difficulty, Guid>, IDifficultyRepository
    {
        public DifficultyRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
