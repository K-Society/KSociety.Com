using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public class S7Tag : IEntityTypeConfiguration<Domain.Entity.S7.S7Tag>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.S7.S7Tag> tagConfiguration)
        {
            //tagConfiguration.ToTable("S7Tag", ComContext.DefaultSchema);

            //tagConfiguration.HasKey(k => k.TagId);
            //tagConfiguration.Property(p => p.TagId).ValueGeneratedOnAdd().IsRequired();

            //tagConfiguration.HasOne(c => c.StdTag).WithMany(cc => cc.S7Tags)
            //    .HasForeignKey(fk => fk.StdTagId).HasConstraintName("ForeignKey_S7Tag_StdTag")
            //    .IsRequired();

            tagConfiguration.Property(p => p.DataBlock);//.IsRequired();

            tagConfiguration.Property(p => p.Offset);//.IsRequired();

            //tagConfiguration.Property(p => p.BitOfByte).IsRequired();
            //tagConfiguration.HasOne(c => c.BitOfByte).WithMany(cc => cc.)
            //    .HasForeignKey(fk => fk.ConnectionTypeId).HasConstraintName("ForeignKey_S7Connection_S7ConnectionType")
            //    .IsRequired();

            //tagConfiguration.HasIndex(i => i.Name).IsUnique();
            //tagConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            //tagConfiguration.Property(p => p.Enable).IsRequired();

            //tagConfiguration.Property(p => p.Address).HasMaxLength(50).IsRequired();

            //tagConfiguration.Property(p => p.Invoke).IsRequired();

            //tagConfiguration.Property(p => p.InputOutput).IsRequired();

            //tagConfiguration.Property(p => p.AnalogDigitalSignal).IsRequired();

            //tagConfiguration.Property(p => p.ConnectionId).IsRequired();

            //tagConfiguration.Property(p => p.WordLenId).IsRequired();

            //tagConfiguration.Property(p => p.AreaId).IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.Bit).WithMany(cc => cc.S7Tags)
                .HasForeignKey(fk => fk.BitOfByte), "ForeignKey_S7Tag_Bit");

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.Area).WithMany(cc => cc.S7Tags)
                .HasForeignKey(fk => fk.AreaId), "ForeignKey_S7Tag_Area");
            //.IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.WordLen).WithMany(cc => cc.S7Tags)
                .HasForeignKey(fk => fk.WordLenId), "ForeignKey_S7Tag_WordLen");
            //.IsRequired();
            tagConfiguration.Property(p => p.StringLength);

            tagConfiguration.Ignore(i => i.DataItemTag);

            //var navigation1 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7Tags));
            //var navigation2 = areaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7BlockAreas));

            //navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);
            //navigation2.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
