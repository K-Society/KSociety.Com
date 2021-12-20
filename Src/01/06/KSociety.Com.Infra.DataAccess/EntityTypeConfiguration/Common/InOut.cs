using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common;

public class InOut : IEntityTypeConfiguration<Domain.Entity.Common.InOut>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Common.InOut> inOutConfiguration)
    {
        //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)inOutConfiguration, "InOut", DatabaseContext.DefaultSchema);
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) inOutConfiguration, "InOut");
            

        inOutConfiguration.HasKey(k => k.InputOutput);
        inOutConfiguration.Property(p => p.InputOutput).ValueGeneratedNever().HasMaxLength(2).IsRequired();

        inOutConfiguration.HasIndex(i => i.InputOutputName).IsUnique();
        inOutConfiguration.Property(p => p.InputOutputName).HasMaxLength(10).IsRequired();

        var inOutNavigation = inOutConfiguration
            .Metadata.FindNavigation(nameof(Domain.Entity.Common.InOut.Tags));

        inOutNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}