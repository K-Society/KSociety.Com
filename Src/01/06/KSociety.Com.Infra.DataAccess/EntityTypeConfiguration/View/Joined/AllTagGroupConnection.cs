using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.View.Joined
{
    public class AllTagGroupConnection : IEntityTypeConfiguration<Domain.Entity.View.Joined.AllTagGroupConnection>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.View.Joined.AllTagGroupConnection> allTagGroupConnectionConfiguration)
        {
            RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder) allTagGroupConnectionConfiguration, "AllTagGroupConnectionView", KSociety.Base.Infra.Shared.Class.DatabaseContext.DefaultSchema);
            allTagGroupConnectionConfiguration.HasNoKey();
        }
    }
}
