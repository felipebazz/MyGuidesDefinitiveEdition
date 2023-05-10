using MediatR;
using MyGuides.Application.Abstractions; 
using MyGuides.Domain.Entities.Users.Queries;
using MyGuides.Domain.Entities.Users.Requests;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;

namespace MyGuides.Application.UseCases.Users.GetUsers
{
    public class GetUsersUseCase : UseCase<GetUserRequest,IEnumerable<UserResult>>, IGetUsersUseCase
    {
        public GetUsersUseCase(IMediator mediator, INotificationService notificationService)
            : base(mediator, notificationService)
        {

        } 

        protected override Task<IEnumerable<UserResult>> OnExecuteAsync(GetUserRequest request, CancellationToken cancellationToken)
        {
            if (request.Username == null)
            {
                return default;
            }
            var query = new GetUsersQuery() { UserName = request.Username };
            return _mediator.Send(query, cancellationToken);
        }
    }
}
