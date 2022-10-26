using AutoMapper;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Game, GameResult>()
                .ReverseMap();
        }
    }
}
