using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public class BlockArea : IEntityTypeConfiguration<Domain.Entity.S7.BlockArea>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.S7.BlockArea> blockAreaConfiguration)
        {
            //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) blockAreaConfiguration, "S7BlockArea", DatabaseContext.DefaultSchema);
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)blockAreaConfiguration, "S7BlockArea");

            blockAreaConfiguration.HasKey(k => k.Id);
            blockAreaConfiguration.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();

            blockAreaConfiguration.HasIndex(i => i.Name).IsUnique();
            blockAreaConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) blockAreaConfiguration.HasOne(c => c.Area).WithMany(cc => cc.S7BlockAreas)
                .HasForeignKey(fk => fk.AreaId), "ForeignKey_S7BlockArea_Area");
            //.IsRequired();

            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder) blockAreaConfiguration.HasOne(c => c.WordLen).WithMany(cc => cc.S7BlockAreas)
                .HasForeignKey(fk => fk.WordLenId), "ForeignKey_S7BlockArea_WordLen");
            //.IsRequired();

            //blockAreaConfiguration.Property(p => p.Name).HasMaxLength(50).IsRequired();

            //blockAreaConfiguration.Property(p => p.Mean).HasMaxLength(50).IsRequired();

            //var tagNavigation = blockAreaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7Tags));
            //var blockAreaNavigation = blockAreaConfiguration.Metadata.FindNavigation(nameof(Domain.Db.Entity.S7.Area.S7BlockAreas));

            //tagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //blockAreaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
