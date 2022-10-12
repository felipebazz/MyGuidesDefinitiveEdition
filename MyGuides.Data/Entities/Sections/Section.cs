using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.Banners;

namespace MyGuides.Domain.Entities.Sections
{
    public class Section : Entity<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsIndividual { get; set; }
        public List<Banner> Banners { get; set; }

        public Section(string name, string content, bool isIndividual)
        {
            Name = name;
            Content = content;
            IsIndividual = isIndividual;
            Banners = new List<Banner>();

            Validate();
        }

        protected Section() { }

        public override bool Validate() => OnValidate(this, new SectionValidator());
    }
}
