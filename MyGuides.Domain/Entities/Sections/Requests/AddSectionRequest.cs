namespace MyGuides.Domain.Entities.Sections.Requests
{
    public class AddSectionRequest
    {
        public string Name { get; set; }
        public bool RepeatBanner { get; set; }
        public List<Guid> AchievementsIds { get; set; }
        public List<SectionBanner> Banners { get; set; }
    }

    public class SectionBanner
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
    }
}
