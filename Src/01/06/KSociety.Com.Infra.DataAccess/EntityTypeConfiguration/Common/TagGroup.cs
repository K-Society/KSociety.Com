using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public class TagGroup : IEntityTypeConfiguration<Domain.Entity.Common.TagGroup>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Common.TagGroup> tagGroupConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) tagGroupConfiguration, "TagGroup", KbDbContext.DefaultSchema);

            tagGroupConfiguration.HasKey(k => k.Id);
            tagGroupConfiguration.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            tagGroupConfiguration.HasIndex(i => i.Name).IsUnique();
            tagGroupConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            tagGroupConfiguration.Property(p => p.Clock).IsRequired();

            tagGroupConfiguration.Property(p => p.Update).IsRequired();

            tagGroupConfiguration.Property(p => p.Enable).IsRequired();

            var tagGroupNavigation = tagGroupConfiguration
                .Metadata.FindNavigation(nameof(Domain.Entity.Common.TagGroup.Tags));

            tagGroupNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
