using MyGuides.Domain.Entities.Difficulties;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Difficulties
{
    public interface IDifficultyRepository : IRepository<Difficulty, Guid>
    {
    }
}
