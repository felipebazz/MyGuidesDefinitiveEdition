using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyGuides.Domain.Entities.Users.Repository;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.Context; 

namespace MyGuides.Domain.Entities.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResult>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;
        private readonly INotificationService _notificationService;
        private readonly UserManager<IdentityUser> _userManager;
        public AddUserCommandHandler(
            IMapper mapper,
            IUsersRepository usersRepository,
            INotificationService notificationService, 
            UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _userRepository = usersRepository;
            _notificationService = notificationService;
            _userManager = userManager;
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
            await _userManager.CreateAsync(new IdentityUser() { Email = user.Email, UserName = user.UserName }, user.Password);
            await _userRepository.AddAsync(user, cancellationToken);
            user.Password = null;
            return _mapper.Map<UserResult>(user);
        }
    }
}
