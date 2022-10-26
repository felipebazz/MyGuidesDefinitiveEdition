using AutoMapper;

namespace MyGuides.Domain.Entities.Games.Converters
{
    public class GameConverter : ITypeConverter<Steam.Api.Responses.Game, Game>
    {
        public Game Convert(Steam.Api.Responses.Game source, Game destination, ResolutionContext context)
        {
            var teste = new Game(Guid.NewGuid(), source.GameName, source.GameVersion, "");

            //teste.Achievements.Add


            return teste;
        }
    }
}
