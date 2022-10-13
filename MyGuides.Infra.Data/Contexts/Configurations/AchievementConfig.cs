using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Achievements;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    [ExcludeFromCodeCoverage]
    public class AchievementConfig : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.ToTable(nameof(Achievement));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.DisplayName)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.Property(p => p.Hidden)
                .IsRequired();

            builder.Property(p => p.Icon)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.IconGray)
                .IsRequired()
                .HasMaxLength(FieldRules.TextFieldMaxLength);

            builder.Property(p => p.Order);

            builder.HasOne(p => p.Game)
                .WithMany()
                .HasForeignKey(f => f.GameId);

            builder.HasOne(p => p.Section)
                .WithMany()
                .HasForeignKey(f => f.SectionId);

            builder.HasOne(p => p.Difficulty)
                .WithMany(p => p.Achievements)
                .HasForeignKey(f => f.DifficultyId);
        }
    }
}
