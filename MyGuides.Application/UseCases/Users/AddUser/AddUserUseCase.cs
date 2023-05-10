using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Users.Commands.AddUser;
using MyGuides.Domain.Entities.Users.Requests;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Users.AddUser;

public class AddUserUseCase : TransactionalUseCase<AddUserRequest, UserResult>, IAddUserUseCase
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AddUserUseCase(IMapper mapper, IConfiguration configuration, IMediator mediator, IUnitOfWork unitOfWork, INotificationService notificationService) : base(mediator, unitOfWork, notificationService) => 
        (_configuration,_mapper) = (configuration, mapper);

    protected override async Task<UserResult> OnExecuteAsync(AddUserRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Username))
        {
            return default;
        }
        if (string.IsNullOrEmpty(request.Email))
        {
            return default;
        }
        if (string.IsNullOrEmpty(request.Password))
        {
            return default;
        }

        var command = new AddUserCommand(request.Username, request.Email, request.Password);
        return await _mediator.Send(command, cancellationToken);

    }
}
