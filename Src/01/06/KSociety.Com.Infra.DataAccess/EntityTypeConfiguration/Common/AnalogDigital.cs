using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common;

public class AnalogDigital : IEntityTypeConfiguration<Domain.Entity.Common.AnalogDigital>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Common.AnalogDigital> analogDigitalConfiguration)
    {
        //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)analogDigitalConfiguration, "AnalogDigital", DatabaseContext.DefaultSchema);
        ((EntityTypeBuilder)analogDigitalConfiguration).ToTable("AnalogDigital");

        analogDigitalConfiguration.HasKey(k => k.AnalogDigitalSignal);
        analogDigitalConfiguration.Property(p => p.AnalogDigitalSignal).ValueGeneratedNever().HasMaxLength(7).IsRequired();

        var analogDigitalNavigation = analogDigitalConfiguration
            .Metadata.FindNavigation(nameof(Domain.Entity.Common.AnalogDigital.Tags));

        analogDigitalNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}