using AutoMapper;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Achievements.Converters;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Converters;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Domain.Entities.Users;
using MyGuides.Domain.Entities.Users.Converters;
using MyGuides.Domain.Entities.Users.Results;

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

            CreateMap<List<User>, List<UserResult>>()
                .ConvertUsing(new ToUserListResultConverter());

            CreateMap<User, UserResult>()
                .ConvertUsing(new ToUserResultConverter());

            CreateMap<AuthResult, AuthResult>();
        }
    }
}
