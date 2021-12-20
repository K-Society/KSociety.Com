using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Logix;

public class LogixConnection : IEntityTypeConfiguration<Domain.Entity.Logix.LogixConnection>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Logix.LogixConnection> connectionConfiguration)
    {
        //var converter = new StringToBytesConverter(Encoding.Unicode);
        connectionConfiguration.Property(p => p.Path).HasMaxLength(3)//.HasColumnType("varbinary(3)")
            .HasDefaultValue(new byte[] { 0, 0, 0 });
        /*.HasDefaultValue(new byte[] { 0x00, 0x00, 0x00 });*/ //.IsRequired(false); //.HasColumnType();//.IsRequired(); no!

    }
}