using Mayhem.Dal.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mayhem.Dal.MappingsConfiguration.Configurations
{
    public class GameVersionMappingConfiguration : IEntityTypeConfiguration<GameVersion>
    {
        public void Configure(EntityTypeBuilder<GameVersion> builder)
        {
            builder.ToTable(nameof(GameVersion));

            builder.Property(e => e.Id);
            builder.Property(e => e.Version).HasMaxLength(50).IsRequired();
            builder.Property(e => e.BuildURL).HasMaxLength(500).IsRequired();
        }
    }
}
