using AutoMapper;
using MediatR; 
using MyGuides.Domain.Entities.Users.Repository;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Domain.Entities.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserResult>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IUsersRepository _usersRepository;

        public GetUsersQueryHandler(IMapper mapper, INotificationService notificationService, IUsersRepository usersRepository) =>  (_notificationService, _usersRepository) = (notificationService, usersRepository);

        public async Task<IEnumerable<UserResult>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                _notificationService.AddNotification(DomainValidationMessages.GetAchievementsQueryHandler_Request_Null);
                return default;
            }

            var users = await _usersRepository.GetAsync(cancellationToken);

            if (users is null)
            {
                _notificationService.AddNotification(DomainValidationMessages.GetAchievementsQueryHandler_Achievements_Null);
                return default;
            }

            return _mapper.Map<List<UserResult>>(users);
        }
    }
}
