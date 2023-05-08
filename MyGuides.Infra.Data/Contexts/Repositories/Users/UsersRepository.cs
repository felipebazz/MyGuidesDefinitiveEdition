using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Users;
using MyGuides.Domain.Entities.Users.Repository;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Data.Contexts.Repositories.Users
{
    public class UsersRepository : Repository<User, Guid>, IUsersRepository
    {
        public UsersRepository(MyGuidesContext dbContext) : base(dbContext)
        {
        }
        
    }
}
