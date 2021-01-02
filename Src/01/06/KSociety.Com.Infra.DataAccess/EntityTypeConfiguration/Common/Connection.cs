using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public class Connection : IEntityTypeConfiguration<Domain.Entity.Common.Connection>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Common.Connection> connectionConfiguration)
        {
            //try
            //{
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) connectionConfiguration, "Connection", DatabaseContext.DefaultSchema);

            connectionConfiguration.HasKey(k => k.Id);
            connectionConfiguration.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) connectionConfiguration.HasOne(c => c.AutomationType)
                    .WithMany(cc => cc.Connections)
                    .HasForeignKey(fk => fk.AutomationTypeId), "ForeignKey_Connection_AutomationType")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            connectionConfiguration.HasDiscriminator(connection => connection.AutomationTypeId)
                .HasValue<Domain.Entity.Common.Connection>(0)
                .HasValue<Domain.Entity.S7.S7Connection>(1)
                .HasValue<Domain.Entity.Logix.LogixConnection>(2)
                .HasValue<Domain.Entity.Modbus.ModbusConnection>(3)
                .HasValue<Domain.Entity.Tcp.TcpConnection>(4);



            connectionConfiguration.HasIndex(i => new { i.Name, i.AutomationTypeId }).IsUnique();
            connectionConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            connectionConfiguration.Property(p => p.Ip).HasMaxLength(15).IsRequired();

            //connectionConfiguration.Property(p => p.Rack).IsRequired();

            //connectionConfiguration.Property(p => p.Slot).IsRequired();

            //connectionConfiguration.HasOne(c => c.ConnectionType).WithMany(cc => cc.Connections)
            //    .HasForeignKey(fk => fk.ConnectionTypeId).HasConstraintName("ForeignKey_S7Connection_S7ConnectionType")
            //    .IsRequired();

            //connectionConfiguration.Property(p => p.RequestedId).IsRequired();

            connectionConfiguration.Property(p => p.Enable).IsRequired();

            connectionConfiguration.Property(p => p.WriteEnable).IsRequired();

            //var s7ConnectionNavigation = connectionConfiguration
            //    .Metadata.FindNavigation(nameof(Domain.Com.Entity.Common.Connection.S7Connections));

            //connectionConfiguration
            //    .HasOne(s7C => s7C.S7Connection)
            //    .WithOne(c => c.StdConnection)
            //    .HasForeignKey<Domain.Com.Entity.S7.Connection>(c => c.StdConnectionId)
            //    .HasConstraintName("ForeignKey_Connection_S7Connection")
            //    .IsRequired();

            //var allenBradleyConnectionNavigation = connectionConfiguration
            //    .Metadata.FindNavigation(nameof(Domain.Com.Entity.Common.Connection.LogixConnections));

            //connectionConfiguration
            //    .HasOne(logixC => logixC.LogixConnection)
            //    .WithOne(c => c.StdConnection)
            //    .HasForeignKey<Domain.Com.Entity.Logix.Connection>(c => c.StdConnectionId)
            //    .HasConstraintName("ForeignKey_Connection_LogixConnection")
            //    .IsRequired();

            var tagNavigation = connectionConfiguration
                .Metadata.FindNavigation(nameof(Domain.Entity.Common.Connection.Tags));

            //s7ConnectionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //allenBradleyConnectionNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            tagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message + " - " + ex.StackTrace);
            //}
        }
    }
}
