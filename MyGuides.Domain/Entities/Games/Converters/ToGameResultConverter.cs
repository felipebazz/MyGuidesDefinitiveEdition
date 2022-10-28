using AutoMapper;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Converters
{
    public class ToGameResultConverter : ITypeConverter<Game, GameResult>
    {
        public GameResult Convert(Game source, GameResult destination, ResolutionContext context)
        {
            destination = new GameResult()
            {
                AppId = source.AppId,
                Id = source.Id,
                Name = source.Name,
                ImportDate = source.ImportDate.ToShortDateString(),
                UpdateDate = source.UpdateDate.HasValue ? source.UpdateDate.Value.ToShortDateString() : null
            };

            return destination;
        }
    }
}
