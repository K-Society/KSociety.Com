using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public class WordLen : IEntityTypeConfiguration<Domain.Entity.S7.WordLen>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.S7.WordLen> wordLenConfiguration)
        {
            //RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) wordLenConfiguration, "S7WordLen", DatabaseContext.DefaultSchema);
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)wordLenConfiguration, "S7WordLen");

            wordLenConfiguration.HasKey(k => k.Id); //.HasMaxLength(12);
            wordLenConfiguration.Property(p => p.Id).ValueGeneratedNever().IsRequired();

            wordLenConfiguration.HasIndex(i => i.WordLenName).IsUnique();
            wordLenConfiguration.Property(p => p.WordLenName).HasMaxLength(12).IsRequired();

            wordLenConfiguration.Property(p => p.Mean).HasMaxLength(50).IsRequired();

            var tagNavigation = wordLenConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.WordLen.S7Tags));
            var blockAreaNavigation = wordLenConfiguration.Metadata.FindNavigation(nameof(Domain.Entity.S7.WordLen.S7BlockAreas));

            tagNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            blockAreaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
