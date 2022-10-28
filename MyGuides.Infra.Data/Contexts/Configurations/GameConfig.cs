using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGuides.Domain.Constants;
using MyGuides.Domain.Entities.Games;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Contexts.Configurations
{
    [ExcludeFromCodeCoverage]
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("binary(16)");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(FieldRules.NameMaxLength);

            builder.Property(p => p.Version)
                .IsRequired();

            builder.Property(p => p.AppId)
                .IsRequired();

            builder.Property(p => p.ImportDate)
                .IsRequired();

            builder.Property(p => p.UpdateDate);

            builder.HasMany(p => p.Achievements)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
