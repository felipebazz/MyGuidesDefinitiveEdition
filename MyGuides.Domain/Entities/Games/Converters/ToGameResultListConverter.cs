using AutoMapper;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Converters
{
    public class ToGameResultListConverter : ITypeConverter<List<Game>, List<GameResult>>
    {
        public List<GameResult> Convert(List<Game> source, List<GameResult> destination, ResolutionContext context)
        {
            //destination = new List<GameResult>();

            destination = source.Select(itens => new GameResult
            {
                AppId = itens.AppId,
                Id = itens.Id,
                Name = itens.Name,
                ImportDate = itens.ImportDate.ToShortDateString(),
                UpdateDate = itens.UpdateDate.HasValue ? itens.UpdateDate.Value.ToShortDateString() : null
            }).ToList();

            //foreach (var game in source)
            //{
            //    destination.Add(new GameResult()
            //    {
            //        AppId = game.AppId,
            //        Id = game.Id,
            //        Name = game.Name,
            //        ImportDate = game.ImportDate.ToShortDateString(),
            //        UpdateDate = game.UpdateDate.HasValue ? game.UpdateDate.Value.ToShortDateString() : null
            //    });
            //}

            return destination;
        }
    }
}
