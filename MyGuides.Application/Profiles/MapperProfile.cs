using AutoMapper;
using MyGuides.Application.UseCases.Games.AddGame.Converters;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Games;

namespace MyGuides.Application.Profiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Steam.Api.Responses.Game, Game>()
                .ConvertUsing(new SteamGameConverter());


            CreateMap<List<Steam.Api.Responses.Achievement>, List<Achievement>>()
                .ConvertUsing(new SteamAchievementsConverter());
        }
    }
}
