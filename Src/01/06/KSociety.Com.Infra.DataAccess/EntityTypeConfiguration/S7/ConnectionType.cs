using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7;

public class ConnectionType : IEntityTypeConfiguration<Domain.Entity.S7.ConnectionType>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.S7.ConnectionType> connectionTypeConfiguration)
    {
        //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) connectionTypeConfiguration, "S7ConnectionType", DatabaseContext.DefaultSchema);
        ((EntityTypeBuilder)connectionTypeConfiguration).ToTable("S7ConnectionType");

        connectionTypeConfiguration.HasKey(k => k.Id);
        connectionTypeConfiguration.Property(p => p.Id).ValueGeneratedNever().IsRequired();

        connectionTypeConfiguration.HasIndex(i => i.Name).IsUnique();
        connectionTypeConfiguration.Property(p => p.Name).HasMaxLength(9).IsRequired();

        var connectionNavigation = connectionTypeConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.ConnectionType.Connections));

        connectionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}