using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Banners;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    public class BannerConfig : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable(nameof(Banner));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("binary(16)")
                .ValueGeneratedNever()
                .HasConversion(c => c.ToByteArray(), c => new Guid(c));

            builder.Property(p => p.ImageId)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.HasOne(p => p.Section)
                .WithMany(p => p.Banners)
                .HasForeignKey(p => p.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.BannerType)
                .WithOne()
                .HasForeignKey<Banner>(p => p.BannerTypeId);
        }
    }
}
