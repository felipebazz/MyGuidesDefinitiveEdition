using AutoMapper;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Converters
{
    public class ToGameResultListConverter : ITypeConverter<List<Game>, List<GameResult>>
    {
        public List<GameResult> Convert(List<Game> source, List<GameResult> destination, ResolutionContext context)
        {
            destination = new List<GameResult>();

            foreach (var game in source)
            {
                destination.Add(new GameResult()
                {
                    AppId = game.AppId,
                    Id = game.Id,
                    Name = game.Name,
                    ImportDate = game.ImportDate.ToShortDateString(),
                    UpdateDate = game.UpdateDate.HasValue ? game.UpdateDate.Value.ToShortDateString() : null
                });
            }

            return destination;
        }
    }
}
