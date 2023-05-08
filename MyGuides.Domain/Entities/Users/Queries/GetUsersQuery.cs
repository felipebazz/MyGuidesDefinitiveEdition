using MediatR;
using MyGuides.Domain.Entities.Users.Results;

namespace MyGuides.Domain.Entities.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserResult>>
    {
        public string UserName { get; set; }
    }
}
