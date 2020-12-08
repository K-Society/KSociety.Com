using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Tcp
{
    public class TcpTag : IEntityTypeConfiguration<Domain.Entity.Tcp.TcpTag>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Tcp.TcpTag> tagConfiguration)
        {

        }
    }
}
