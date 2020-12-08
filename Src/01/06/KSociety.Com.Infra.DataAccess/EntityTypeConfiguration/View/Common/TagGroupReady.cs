using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.View.Common
{
    public class TagGroupReady : IEntityTypeConfiguration<Domain.Entity.View.Common.TagGroupReady>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.View.Common.TagGroupReady> tagGroupReadyConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder) tagGroupReadyConfiguration, "TagGroupReadyView", KSociety.Base.Infra.Shared.Class.KbDbContext.DefaultSchema);

            tagGroupReadyConfiguration.HasNoKey();
        }
    }
}
