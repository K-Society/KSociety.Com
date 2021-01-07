using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public class Area : IEntityTypeConfiguration<Domain.Entity.S7.Area>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.S7.Area> areaConfiguration)
        {
            //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) areaConfiguration, "S7Area", DatabaseContext.DefaultSchema);

            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)areaConfiguration, "S7Area");
            //areaConfiguration.HasKey(k => new {k.AreaId, k.AreaName});
            areaConfiguration.HasKey(k => k.Id);
            areaConfiguration.Property(p => p.Id).ValueGeneratedNever().IsRequired();
            //areaConfiguration.Property(p => p.AreaId).HasMaxLength(2).IsRequired();

            areaConfiguration.HasIndex(i => i.AreaName).IsUnique();
            areaConfiguration.Property(p => p.AreaName).HasMaxLength(8).IsRequired();

            areaConfiguration.Property(p => p.Mean).HasMaxLength(50).IsRequired();

            var tagNavigation = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.Area.S7Tags));
            var blockAreaNavigation = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.Area.S7BlockAreas));

            tagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            blockAreaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
