using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Domain.Entities.BannerTypes.Types;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    public class BannerTypeConfig : IEntityTypeConfiguration<BannerType>
    {
        public void Configure(EntityTypeBuilder<BannerType> builder)
        {
            builder.ToTable(nameof(BannerType));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.HasDiscriminator(nameof(BannerType.Id), typeof(int))
                .HasValue<Header>(Header.Discriminator)
                .HasValue<Divisor>(Divisor.Discriminator);
        }
    }
}
