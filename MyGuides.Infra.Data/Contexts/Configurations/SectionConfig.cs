using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Sections;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    public class SectionConfig : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable(nameof(Section));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.Property(p => p.IsIndividual)
                .IsRequired();
        }
    }
}
