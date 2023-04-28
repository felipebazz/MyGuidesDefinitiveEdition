using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.Achievements;

namespace MyGuides.Domain.Entities.Games
{
    public class Game : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string AppId { get; private set; }
        public List<Achievement> Achievements { get; private set; }
        public DateTime ImportDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public string Image { get; private set; }
        public string BackgroundImage { get; private set; }

        public Game(Guid id, string name, string version, string appId, string image = null, string backgroundImage = null)
            : base(id)
        {
            Name = name;
            Version = version;
            AppId = appId;
            ImportDate = DateTime.Now;
            Achievements = new List<Achievement>();
            Image = image;
            BackgroundImage = backgroundImage;

            Validate();
        }

        protected Game() { }
        public void AddAchievement(List<Achievement> achievements) => Achievements.AddRange(achievements);

        public void AddAchievement(Achievement achievement) => Achievements.Add(achievement);

        public void SetUpdateDate() => UpdateDate = DateTime.Now;

        public void SetImage(string image) => Image = image;

        public void SetBackgroundImage(string backgroundImage) => BackgroundImage = backgroundImage;

        public override bool Validate() => OnValidate(this, new GameValidator());
    }
}
