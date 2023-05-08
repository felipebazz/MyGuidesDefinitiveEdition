using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Games.Commands.AddGame;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Domain.Entities.Users.Repository;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Domain.Entities.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResult>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;
        private readonly INotificationService _notificationService;

        public AddUserCommandHandler(
            IMapper mapper,
            IUsersRepository usersRepository,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _userRepository = usersRepository;
            _notificationService = notificationService;
        }

        public async Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.Any(u => request.UserName.Equals(u.UserName)))
            {
                _notificationService.AddNotification(DomainValidationMessages.AddGameCommandHandler_Game_Exists);
                return default;
            }
            
            if (_userRepository.Any(u => request.Email.Equals(u.Email)))
            {
                _notificationService.AddNotification(DomainValidationMessages.AddGameCommandHandler_Game_Exists);
                return default;
            }
            
            User user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password
            };

            user.Validate();

            if (!user.Valid)
            {
                _notificationService.AddNotification(string.Format(DomainValidationMessages.AddGameCommandHandler_Game_Invalid, user.ValidationResult.Errors.Count));
                return default;
            }

            await _userRepository.AddAsync(user, cancellationToken);
            return _mapper.Map<UserResult>(user);
        }
    }
}
