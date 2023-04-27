using MediatR;
using MyGuides.Domain.Entities.Games.Results;
using Steam.Api.Responses;

namespace MyGuides.Domain.Entities.Games.Commands.AddGame
{
    public class AddGameCommand : IRequest<GameResult>
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string AppId { get; set; }
        public string Image { get; set; }
        public string BackgroundImage { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }

        public AddGameCommand(string name, string version, string appId, IEnumerable<Achievement> achievements, string image = null, string backgroundImage = null)
        {
            Name = name;
            Version = version;
            AppId = appId;
            Achievements = achievements ?? new List<Achievement>();
            Image = image;
            BackgroundImage = backgroundImage;
        }

        public AddGameCommand()
        {
        }
    }
}
