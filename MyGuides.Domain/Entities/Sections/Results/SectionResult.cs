
using MyGuides.Domain.Entities.Achievements.Results;

namespace MyGuides.Domain.Entities.Sections.Results
{
    public class SectionResult
    {
        public string Name { get; set; }
        public List<BannerResult> Banners { get; set; }
        public List<AchievementResult> Achievements { get; set; }
    }

    //public class AchievementResult
    //{

    //}

    public class BannerResult
    {

    }
}
