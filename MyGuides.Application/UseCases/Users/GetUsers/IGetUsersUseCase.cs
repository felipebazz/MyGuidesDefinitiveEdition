using MyGuides.Domain.Entities.Users.Requests;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Users.GetUsers;

public interface IGetUsersUseCase : INotifiableUseCase<GetUserRequest,IEnumerable<UserResult>>
{
}
