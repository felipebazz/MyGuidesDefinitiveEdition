using MyGuides.Domain.Abstractions.Repository;

namespace MyGuides.Domain.Entities.Difficulties.Repository
{
    public interface IDifficultyRepository : IRepository<Difficulty, Guid>
    {
    }
}
