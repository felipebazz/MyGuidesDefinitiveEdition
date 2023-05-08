using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results;
using MyGuides.Notifications.UseCaseAbstractions; 

namespace MyGuides.Application.UseCases.Auth
{
    internal interface ICreateTokenUseCase : INotifiableUseCase<CreateTokenRequest, AuthResult>
    {
    }
}
