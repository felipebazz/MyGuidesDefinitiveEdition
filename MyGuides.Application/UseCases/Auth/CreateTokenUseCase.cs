using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Auth.Commands;
using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context; 

namespace MyGuides.Application.UseCases.Auth
{
    public class CreateTokenUseCase : TransactionalUseCase<CreateTokenRequest, AuthResult>, ICreateTokenUseCase
    {
        public CreateTokenUseCase(IMediator mediator,INotificationService notification, IUnitOfWork unitOfWork) : base(mediator, unitOfWork, notification)
        {
        }
        protected override async Task<AuthResult> OnExecuteAsync(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTokenCommand()
            {
                Password = request.Password,
                UserName = request.UserName
            };
            return await _mediator.Send(command, cancellationToken);
        }
    }
}
