using MyGuides.Domain.Abstractions.Entities;

namespace MyGuides.Domain.Entities.Sections
{
    public class Section : Entity<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsIndividual { get; set; }
        public Guid? HeaderImageId { get; set; }
        public Guid? DivisorImageId { get; set; }

        public Section(string name, string content, string? headerImageId, string? divisorImageId, bool isIndividual)
        {
            Name = name;
            Content = content;
            IsIndividual = isIndividual;

            Validate();
        }

        public void SetHeaderImage(Guid headerImageId)
        {
            HeaderImageId = headerImageId;
        }

        public void SetDivisorImageId(Guid divisorImageId)
        {
            DivisorImageId = divisorImageId;
        }

        public override bool Validate() => OnValidate(this, new SectionValidator());
    }
}
