using MyGuides.Domain.Abstractions.Repository;

namespace MyGuides.Domain.Entities.Games.Repository
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}
