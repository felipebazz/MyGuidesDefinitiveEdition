using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Games
{
    public class GameRepository : Repository<Game, Guid>, IGameRepository
    {
        public GameRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public override Task UpdateAsync(Game entity, CancellationToken cancellationToken)
        {
            entity.SetUpdateDate();

            return base.UpdateAsync(entity, cancellationToken);
        }
    }
}
