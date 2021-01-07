using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.View.Joined
{
    public class AllTagGroupAllConnection : IEntityTypeConfiguration<Domain.Entity.View.Joined.AllTagGroupAllConnection>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.View.Joined.AllTagGroupAllConnection> allTagGroupAllConnectionConfiguration)
        {
            //RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder) allTagGroupAllConnectionConfiguration, "AllTagGroupAllConnectionView", KSociety.Base.Infra.Shared.Class.DatabaseContext.DefaultSchema);
            RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder)allTagGroupAllConnectionConfiguration, "AllTagGroupAllConnectionView");
            allTagGroupAllConnectionConfiguration.HasNoKey();
        }
    }
}
