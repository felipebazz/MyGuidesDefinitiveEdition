using MyGuides.Domain.Entities.Games;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Games
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}
