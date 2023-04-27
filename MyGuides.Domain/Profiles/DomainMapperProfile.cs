using AutoMapper;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Achievements.Converters;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Converters;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Profiles
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Game, GameResult>()
                .ConvertUsing(new ToGameResultConverter());

            CreateMap<List<Game>, List<GameResult>>()
                .ConvertUsing(new ToGameResultListConverter());

            CreateMap<List<Achievement>, List<AchievementResult>>()
                .ConvertUsing(new ToAchievementResultConverter());

            CreateMap<Tuple<IEnumerable<Steam.Api.Responses.Achievement>, Guid>, List<Achievement>>()
                .ConvertUsing(new StoreToAchievementConverter());
        }
    }
}
