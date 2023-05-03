using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Banners;

namespace MyGuides.Domain.Entities.Sections
{
    public class Section : Entity<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsIndividual { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Achievement> Achievements { get; set; }

        public Section(string name, bool isIndividual, string content = null)
        {
            Name = name;
            IsIndividual = isIndividual;
            Banners = new List<Banner>();
            Achievements = new List<Achievement>();

            AddContent(content);
            Validate();
        }

        protected Section() { }

        public void AddContent(string content) => Content = content;

        public void AddAchievement(Achievement achievement) => Achievements.Add(achievement);

        public void AddAchievement(List<Achievement> achievements) => Achievements.AddRange(achievements);

        public override bool Validate() => OnValidate(this, new SectionValidator());
    }
}
