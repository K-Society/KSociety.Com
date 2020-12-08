using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public class Bit : IEntityTypeConfiguration<Domain.Entity.Common.Bit>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Common.Bit> bitConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) bitConfiguration, "Bit", KbDbContext.DefaultSchema);

            bitConfiguration.HasKey(k => k.BitOfByte);
            bitConfiguration.Property(p => p.BitOfByte).ValueGeneratedNever().IsRequired();

            bitConfiguration.HasIndex(i => i.BitName).IsUnique();
            bitConfiguration.Property(p => p.BitName).HasMaxLength(5).IsRequired();

            var bitNavigation = bitConfiguration
                .Metadata.FindNavigation(nameof(Domain.Entity.Common.Bit.S7Tags));

            bitNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
