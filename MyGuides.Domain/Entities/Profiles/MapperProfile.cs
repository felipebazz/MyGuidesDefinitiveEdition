using AutoMapper;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Achievements.Converters;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Converters;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Steam.Api.Responses.Game, Game>()
                .ConvertUsing(new GameConverter());

            CreateMap<Game, GameResult>()
                .ReverseMap();

            CreateMap<List<Steam.Api.Responses.Achievement>, List<Achievement>>()
                .ConvertUsing(new AchievementsConverter());
        }
    }
}
