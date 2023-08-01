using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.View.Joined;

public class AllConnection : IEntityTypeConfiguration<Domain.Entity.View.Joined.AllConnection>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.View.Joined.AllConnection> allConnectionConfiguration)
    {
        //RelationalEntityTypeBuilderExtensions.ToView((EntityTypeBuilder) allConnectionConfiguration, "AllConnectionView", KSociety.Base.Infra.Shared.Class.DatabaseContext.DefaultSchema);
        ((EntityTypeBuilder)allConnectionConfiguration).ToView("AllConnectionView");
        allConnectionConfiguration.HasNoKey();
    }
}