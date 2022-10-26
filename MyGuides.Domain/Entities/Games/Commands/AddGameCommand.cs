using MediatR;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Commands
{
    public class AddGameCommand : IRequest<GameResult>
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string AppId { get; set; }
        public List<Achievement> Achievements { get; set; }

        public AddGameCommand(string name, string version, string appId, List<Achievement> achievements)
        {
            Name = name;
            Version = version;
            AppId = appId;
            Achievements = achievements ?? new List<Achievement>();
        }

        public AddGameCommand()
        {
        }
    }
}
