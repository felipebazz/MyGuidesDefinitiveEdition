using MyGuides.Domain.Abstractions.Repository;
using MyGuides.Domain.Entities.Difficulties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Domain.Entities.Users.Repository
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
    }
}
