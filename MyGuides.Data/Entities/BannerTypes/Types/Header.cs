namespace MyGuides.Domain.Entities.BannerTypes.Types
{
    public class Header : BannerType
    {
        public const int Discriminator = 1;

        public Header(string name) 
            : base(Discriminator, name)
        {
        }

        public override bool Validate() => OnValidate(this, new BannerTypeValidator<Header>());
    }
}
