using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Achievements.Repositories;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Domain.Entities.Achievements.Queries.GetAchievements
{
    public class GetAchievementsQueryHandler : IRequestHandler<GetAchievementsQuery, IEnumerable<AchievementResult>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IAchievementRepository _achievementRepository;
        public GetAchievementsQueryHandler(
            IMapper mapper,
            INotificationService notificationService,
            IAchievementRepository achievementRepository)
        {
            _mapper = mapper;
            _notificationService = notificationService;
            _achievementRepository = achievementRepository;
        }
        public async Task<IEnumerable<AchievementResult>> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                _notificationService.AddNotification(DomainValidationMessages.GetAchievementsQueryHandler_Request_Null);
                return default;
            }

            var achievements = await _achievementRepository.GetAsync(
                a => a.GameId == request.GameId,
                cancellationToken,
                include: source => source.Include(d => d.Difficulty));

            if (achievements is null)
            {
                _notificationService.AddNotification(DomainValidationMessages.GetAchievementsQueryHandler_Achievements_Null);
                return default;
            }

            return _mapper.Map<List<AchievementResult>>(achievements);
        }
    }
}
