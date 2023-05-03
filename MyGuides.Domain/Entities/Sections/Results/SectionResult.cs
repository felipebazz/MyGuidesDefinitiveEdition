using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Banners;

namespace MyGuides.Domain.Entities.Sections.Results
{
    public class SectionResult
    {
        public string Name { get; set; }
        public List<Banner> Banners { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
