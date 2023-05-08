using MyGuides.Domain.Abstractions.Repository;

namespace MyGuides.Domain.Entities.Games.Repository
{
    public interface IUserRepository : IRepository<Game, Guid>
    {
    }
}
