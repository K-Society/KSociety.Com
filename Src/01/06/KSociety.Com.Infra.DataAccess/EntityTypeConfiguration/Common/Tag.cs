using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public class Tag : IEntityTypeConfiguration<Domain.Entity.Common.Tag>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Common.Tag> tagConfiguration)
        {

            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) tagConfiguration, "Tag", KSociety.Base.Infra.Shared.Class.DatabaseContext.DefaultSchema);

            tagConfiguration.HasKey(k => k.Id);
            tagConfiguration.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.AutomationType)
                    .WithMany(cc => cc.Tags)
                    .HasForeignKey(fk => fk.AutomationTypeId), "ForeignKey_Tag_AutomationType")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            tagConfiguration.HasDiscriminator(d => d.AutomationTypeId)
                .HasValue<Domain.Entity.Common.Tag>(0)
                .HasValue<Domain.Entity.S7.S7Tag>(1)
                .HasValue<Domain.Entity.Logix.LogixTag>(2)
                .HasValue<Domain.Entity.Modbus.ModbusTag>(3)
                .HasValue<Domain.Entity.Tcp.TcpTag>(4);


            //tagConfiguration.HasOne(c => c.AutomationType).WithMany(cc => cc.StdTags)
            //    .HasForeignKey(fk => fk.AutomationTypeId).HasConstraintName("ForeignKey_Tag_AutomationType")
            //    .IsRequired();

            tagConfiguration.HasIndex(i => new { i.Name, i.AutomationTypeId }).IsUnique();
            tagConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.Connection)
                    .WithMany(cc => cc.Tags)
                    .HasForeignKey(fk => fk.ConnectionId), "ForeignKey_Tag_ConnectionId")
                .IsRequired();

            tagConfiguration.Property(p => p.Enable).IsRequired();

            tagConfiguration.Property(p => p.MemoryAddress).HasMaxLength(50).IsRequired();

            tagConfiguration.Property(p => p.Invoke).IsRequired();

            //tagConfiguration.Property(p => p.InputOutput).IsRequired();
            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.InOut).WithMany(cc => cc.Tags)
                    .HasForeignKey(fk => fk.InputOutput), "ForeignKey_Tag_InOut")
                .IsRequired();

            //tagConfiguration.Property(p => p.AnalogDigitalSignal).IsRequired();
            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.AnalogDigital).WithMany(cc => cc.Tags)
                    .HasForeignKey(fk => fk.AnalogDigitalSignal), "ForeignKey_Tag_AnalogDigital")
                .IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) tagConfiguration.HasOne(c => c.TagGroup).WithMany(cc => cc.Tags)
                    .HasForeignKey(fk => fk.TagGroupId), "ForeignKey_Tag_TagGroup")
                .IsRequired();

            tagConfiguration.Ignore(i => i.OldValue);

            tagConfiguration.Ignore(i => i.Value);

            tagConfiguration.Ignore(i => i.Timestamp);

            //tagConfiguration.Ignore(i => i.TagReadEvent);
            //tagConfiguration.Ignore(i => i.TagWriteEvent);

            //tagConfiguration
            //    .HasOne(s7T => s7T.S7Tag)
            //    .WithOne(t => t.StdTag)
            //    .HasForeignKey<Domain.Com.Entity.S7.S7Tag>(t => t.StdTagId)
            //    .HasConstraintName("ForeignKey_Tag_S7Tag")
            //    .IsRequired();

            //tagConfiguration
            //    .HasOne(logixT => logixT.LogixTag)
            //    .WithOne(t => t.StdTag)
            //    .HasForeignKey<Domain.Com.Entity.Logix.LogixTag>(t => t.StdTagId)
            //    .HasConstraintName("ForeignKey_Tag_LogixTag")
            //    .IsRequired();

            //var s7TagNavigation = tagConfiguration
            //    .Metadata.FindNavigation(nameof(Domain.Com.Entity.Common.Tag.S7Tags));

            //var allenBradleyTagNavigation = tagConfiguration
            //    .Metadata.FindNavigation(nameof(Domain.Com.Entity.Common.Tag.LogixTags));

            //s7TagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //allenBradleyTagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
