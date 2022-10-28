using AutoMapper;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Games.Converters;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Profiles
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Game, GameResult>()
                .ConvertUsing(new ToGameResultConverter());

            CreateMap<List<Game>, List<GameResult>>()
                .ConvertUsing(new ToGameResultListConverter());
        }
    }
}
