using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;

namespace SS.Persistence.EntityConfigurations
{
    public class ArquivoConfiguration : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("Arquivos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeOriginal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NomeArmazenado).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ContentType).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Extensao).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.StorageProvider).HasMaxLength(100);
            builder.Property(x => x.Checksum).HasMaxLength(255);
        }
    }
}
