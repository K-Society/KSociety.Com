using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public class AutomationType : IEntityTypeConfiguration<Domain.Entity.Common.AutomationType>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Common.AutomationType> automationTypeConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) automationTypeConfiguration, "AutomationType", KbDbContext.DefaultSchema);

            automationTypeConfiguration.HasKey(k => k.Id);
            automationTypeConfiguration.Property(p => p.Id).ValueGeneratedNever().IsRequired();

            automationTypeConfiguration.HasIndex(i => i.Name).IsUnique();
            automationTypeConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            automationTypeConfiguration.Property(p => p.Mean).HasMaxLength(200).IsRequired();

            var connectionTypeNavigation = automationTypeConfiguration
                .Metadata.FindNavigation(nameof(Domain.Entity.Common.AutomationType.Connections));

            var tagTypeNavigation = automationTypeConfiguration
                .Metadata.FindNavigation(nameof(Domain.Entity.Common.AutomationType.Tags));

            connectionTypeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            tagTypeNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
