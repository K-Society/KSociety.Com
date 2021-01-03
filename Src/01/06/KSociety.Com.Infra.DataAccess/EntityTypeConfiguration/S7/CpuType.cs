using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public class CpuType : IEntityTypeConfiguration<Domain.Entity.S7.CpuType>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.S7.CpuType> cpuTypeConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) cpuTypeConfiguration, "S7CpuType", DatabaseContext.DefaultSchema);

            cpuTypeConfiguration.HasKey(k => k.Id);
            cpuTypeConfiguration.Property(p => p.Id).ValueGeneratedNever().IsRequired();

            cpuTypeConfiguration.HasIndex(i => i.CpuTypeName).IsUnique();
            cpuTypeConfiguration.Property(p => p.CpuTypeName).HasMaxLength(12).IsRequired();

            cpuTypeConfiguration.Property(p => p.Mean).HasMaxLength(50).IsRequired();

            var s7ConnectionNavigation = cpuTypeConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.CpuType.S7Connections));

            s7ConnectionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
