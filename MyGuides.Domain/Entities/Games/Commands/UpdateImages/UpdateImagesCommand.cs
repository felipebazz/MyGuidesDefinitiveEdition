using MediatR;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Commands.UpdateImages
{
    public class UpdateImagesCommand : IRequest<GameResult>
    {
        public Guid GameId { get; set; }
        public string Image { get; set; }
        public string BackgroundImage { get; set; }
    }
}
