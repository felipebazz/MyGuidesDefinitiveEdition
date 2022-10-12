using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Domain.Entities.Sections;

namespace MyGuides.Domain.Entities.Banners
{
    public class Banner : Entity<Guid>
    {
        public string ImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int BannerTypeId { get; set; }
        public BannerType BannerType { get; set; }
        public Guid SectionId { get; set; }
        public Section Section { get; set; }

        public Banner(Guid id, string bannerId, string bannerName, string bannerURL, BannerType bannerType, Section section)
            : base(id)
        {
            ImageId = bannerId;
            Name = bannerName;
            Url = bannerURL;
            SetBannerType(bannerType);
            SetSection(section);

            Validate();
        }

        protected Banner() { }

        public void SetBannerType(BannerType bannerType)
        {
            if (bannerType is null)
                return;

            BannerType = bannerType;
            BannerTypeId = bannerType.Id;
        }

        public void SetSection(Section section)
        {
            if (section is null)
                return;

            Section = section;
            SectionId = section.Id;
        }

        public override bool Validate() => OnValidate(this, new BannerValidator());
    }
}
