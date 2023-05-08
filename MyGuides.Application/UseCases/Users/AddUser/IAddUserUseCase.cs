using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results;
using MyGuides.Domain.Entities.Users.Requests;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Users.AddUser;

public interface IAddUserUseCase : INotifiableUseCase<AddUserRequest, UserResult>
{
}
