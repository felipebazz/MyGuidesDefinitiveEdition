using MyGuides.Domain.Abstractions.Entities;
using MyGuides.Domain.Entities.BannerTypes;

namespace MyGuides.Domain.Entities.Banners
{
    public abstract class Banner : Entity<Guid>
    {
        public string ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public int BannerTypeId { get; set; }
        public BannerType BannerType { get; set; }

        public Banner(Guid id, string imageId, string imageName, string imageURL, BannerType bannerType)
            : base(id)
        {
            ImageId = imageId;
            ImageName = imageName;
            ImageURL = imageURL;
            SetBannerType(bannerType);

            Validate();
        }

        public void SetBannerType(BannerType bannerType)
        {
            if (bannerType is null)
                return;

            BannerType = bannerType;
            BannerTypeId = bannerType.Id;
        }

        public override bool Validate() => OnValidate(this, new BannerValidator());
    }
}
