using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.Achievements;

namespace MyGuides.Domain.Entities.Difficulties
{
    public class Difficulty : Entity<Guid>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string? ImageId { get; set; }
        public long Order { get; set; }
        public List<Achievement> Achievements { get; set; }

        public Difficulty(string name, string image, long order, List<Achievement> achievements)
        {
            Name = name;
            Image = image;
            Order = order;
            SetAchievements(achievements);

            Validate();
        }

        public void SetAchievements(List<Achievement> achievements)
        {
            if (achievements is null)
                return;

            Achievements = achievements;
        }

        public void SetDifficultyImageId(string imageId)
        {
            if (imageId is null) return;
            ImageId = imageId;
        }

        public override bool Validate() => OnValidate(this, new DifficultyValidator());
    }
}
