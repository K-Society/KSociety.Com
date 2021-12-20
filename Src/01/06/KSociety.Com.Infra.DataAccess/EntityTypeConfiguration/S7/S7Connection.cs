using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7;

public class S7Connection : IEntityTypeConfiguration<Domain.Entity.S7.S7Connection>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.S7.S7Connection> connectionConfiguration)
    {
        //connectionConfiguration.HasBaseType<Domain.Com.Entity.Common.Connection>();
        //connectionConfiguration.ToTable("S7Connection", ComContext.DefaultSchema);

        //connectionConfiguration.HasKey(k => k.S7ConnectionId);
        //connectionConfiguration.Property(p => p.S7ConnectionId).ValueGeneratedOnAdd().IsRequired();

        //connectionConfiguration.HasOne(c => c.StdConnection).WithMany(cc => cc.S7Connections)
        //    .HasForeignKey(fk => fk.StdConnectionId).HasConstraintName("ForeignKey_S7Connection_StdConnectionId")
        //    .IsRequired();

        //connectionConfiguration.HasIndex(i => i.Name).IsUnique();
        //connectionConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

        //connectionConfiguration.Property(p => p.Ip).HasMaxLength(15).IsRequired();
        RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) connectionConfiguration.HasOne(p => p.CpuType).WithMany(pp => pp.S7Connections)
            .HasForeignKey(fk => fk.CpuTypeId), "ForeignKey_S7Connection_S7CpuType");
        //.IsRequired();

        //connectionConfiguration.Property(p => p.CpuType).HasDefaultValue(0);
            

        connectionConfiguration.Property(p => p.Rack).HasDefaultValue((short)0);//.IsRequired();

        connectionConfiguration.Property(p => p.Slot).HasDefaultValue((short)0);//.IsRequired();

        RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) connectionConfiguration.HasOne(c => c.ConnectionType).WithMany(cc => cc.Connections)
            .HasForeignKey(fk => fk.ConnectionTypeId), "ForeignKey_S7Connection_S7ConnectionType");

        //connectionConfiguration.Property(p => p.ConnectionType).HasDefaultValue(1);
        //.IsRequired();

        //connectionConfiguration.Ignore(i => i.ConnectionId);
        //connectionConfiguration.Ignore(i => i.AutomationTypeId);
        //connectionConfiguration.Ignore(i => i.AutomationType);
        //connectionConfiguration.Ignore(i => i.Name);
        //connectionConfiguration.Ignore(i => i.Ip);
        //connectionConfiguration.Ignore(i => i.Enable);
        //connectionConfiguration.Ignore(i => i.WriteEnable);
        ////connectionConfiguration.Ignore(i => i.S7Connection);
        ////connectionConfiguration.Ignore(i => i.LogixConnection);
        //connectionConfiguration.Ignore(i => i.Tags);


        connectionConfiguration.Ignore(i => i.ClientRead);
        connectionConfiguration.Ignore(i => i.ClientWrite);


        //connectionConfiguration.Property(p => p.RequestedId).IsRequired();

        //connectionConfiguration.Property(p => p.Enable).IsRequired();

        //connectionConfiguration.Property(p => p.WriteEnable).IsRequired();
        //var navigation1 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7Tags));
        //var navigation2 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7BlockAreas));

        //navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
        //navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}