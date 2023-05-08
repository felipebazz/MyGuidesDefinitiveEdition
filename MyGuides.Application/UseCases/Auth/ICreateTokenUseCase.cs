using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results;
using MyGuides.Notifications.UseCaseAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Application.UseCases.Auth
{
    internal interface ICreateTokenUseCase : INotifiableUseCase<CreateTokenRequest, AuthResult>
    {
    }
}
