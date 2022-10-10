using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.Difficulties;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Sections;

namespace MyGuides.Domain.Entities.Achievements
{
    public class Achievement : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string DisplayName { get; private set; }
        public bool Hidden { get; private set; }
        public string Icon { get; private set; }
        public string IconGray { get; private set; }
        public long? Order { get; private set; }
        public Guid GameId { get; private set; }
        public Game Game { get; private set; }
        public Guid? SectionId { get; private set; }
        public Section? Section { get; private set; }
        public Guid? DifficultyId { get; private set; }
        public Difficulty? Difficulty { get; private set; }

        public Achievement(Guid id, string name, string description, string displayName, bool hidden, string icon, string iconGray, Game game)
            : base(id)
        {
            Name = name;
            Description = description;
            DisplayName = displayName;
            Hidden = hidden;
            Icon = icon;
            IconGray = iconGray;
            SetGame(game);

            Validate();
        }

        private void SetGame(Game game)
        {
            if (game is null)
                return;

            Game = game;
            GameId = game.Id;
        }

        public void SetOrder(long order)
        {
            Order = order;
        }

        public void SetSection(Section section)
        {
            if (section is null) return;
            Section = section;
            SectionId = section.Id;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            if (difficulty is null) return;
            Difficulty = difficulty;
            DifficultyId = difficulty.Id;
        }

        public void SetDescription(string description)
        {
            if (description is null) return;
            Description = description;
            Validate();
        }

        public override bool Validate() => OnValidate(this, new AchievementValidator());
    }
}
