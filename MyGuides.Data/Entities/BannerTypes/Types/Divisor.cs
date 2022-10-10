namespace MyGuides.Domain.Entities.BannerTypes.Types
{
    public class Divisor : BannerType
    {
        public const int Discriminator = 2;

        public Divisor(string name)
            : base(Discriminator, name)
        {
        }

        public override bool Validate() => OnValidate(this, new BannerTypeValidator<Divisor>());
    }
}
