using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Difficulties;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    [ExcludeFromCodeCoverage]
    public class DifficultyConfig : IEntityTypeConfiguration<Difficulty>
    {
        public void Configure(EntityTypeBuilder<Difficulty> builder)
        {
            builder.ToTable(nameof(Difficulty));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.ImageId);

            builder.Property(p => p.Order)
                .IsRequired();
        }
    }
}
