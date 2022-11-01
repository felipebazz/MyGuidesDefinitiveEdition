using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Achievements.Repositories;
using MyGuides.Domain.Entities.Achievements.Results;

namespace MyGuides.Domain.Entities.Achievements.Queries.GetAchievements
{
    public class GetAchievementsQueryHandler : IRequestHandler<GetAchievementsQuery, IEnumerable<AchievementResult>>
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IMapper _mapper;
        public GetAchievementsQueryHandler(IAchievementRepository achievementRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AchievementResult>> Handle(GetAchievementsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                //cadastrar notificação
                return default;
            }

            var achievements = await _achievementRepository.GetAsync(
                a => a.GameId == request.GameId,
                cancellationToken,
                include: source => source.Include(d => d.Difficulty));

            if (achievements is null)
            {
                //cadastrar notificação
                return default;
            }

            return _mapper.Map<List<AchievementResult>>(achievements);
        }
    }
}
