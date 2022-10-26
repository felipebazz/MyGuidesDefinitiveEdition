using AutoMapper;
using MyGuides.Domain.Entities.Games;

namespace MyGuides.Application.UseCases.Games.AddGame.Converters
{
    public class SteamGameConverter : ITypeConverter<Steam.Api.Responses.Game, Game>
    {
        public Game Convert(Steam.Api.Responses.Game source, Game destination, ResolutionContext context)
        {
            destination = new Game(Guid.NewGuid(), source.GameName, source.GameVersion, source.AppId);

            return destination;
        }
    }
}
