using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Logix;

public class LogixTag : IEntityTypeConfiguration<Domain.Entity.Logix.LogixTag>
{
    public void Configure(EntityTypeBuilder<Domain.Entity.Logix.LogixTag> tagConfiguration)
    {
        //tagConfiguration.ToTable("LogixTag", ComContext.DefaultSchema);

        //tagConfiguration.Property(p => p.Address).HasMaxLength(50).IsRequired();
        //tagConfiguration.HasKey(k => k.TagId);
        //tagConfiguration.Property(p => p.TagId).ValueGeneratedOnAdd().IsRequired();

        //tagConfiguration.HasOne(c => c.StdTag).WithMany(cc => cc.LogixTags)
        //    .HasForeignKey(fk => fk.StdTagId).HasConstraintName("ForeignKey_LogixTag_StdTag")
        //    .IsRequired();

        //tagConfiguration.Property(p => p.DataBlock).IsRequired();

        //tagConfiguration.Property(p => p.Offset).IsRequired();

        //tagConfiguration.Property(p => p.BitOfByte).IsRequired();
        //tagConfiguration.HasOne(c => c.BitOfByte).WithMany(cc => cc.)
        //    .HasForeignKey(fk => fk.ConnectionTypeId).HasConstraintName("ForeignKey_S7Connection_S7ConnectionType")
        //    .IsRequired();

        //tagConfiguration.HasIndex(i => i.Name).IsUnique();
        //tagConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

        //tagConfiguration.Property(p => p.Enable).IsRequired();

        //tagConfiguration.Property(p => p.Invoke).IsRequired();

        //tagConfiguration.Property(p => p.InputOutput).IsRequired();

        //tagConfiguration.Property(p => p.AnalogDigitalSignal).IsRequired();

        //tagConfiguration.Property(p => p.ConnectionId).IsRequired();

        //tagConfiguration.Property(p => p.WordLenId).IsRequired();

        //tagConfiguration.Property(p => p.AreaId).IsRequired();

        //var navigation1 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7Tags));
        //var navigation2 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7BlockAreas));

        //navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
        //navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}