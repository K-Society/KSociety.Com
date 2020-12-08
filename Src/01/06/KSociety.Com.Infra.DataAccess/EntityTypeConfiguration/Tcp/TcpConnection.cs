using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Tcp
{
    public class TcpConnection : IEntityTypeConfiguration<Domain.Entity.Tcp.TcpConnection>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Tcp.TcpConnection> connectionConfiguration)
        {

        }
    }
}
