using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;

namespace SS.Persistence.EntityConfigurations
{
    public class ArtistaConfiguration : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Descricao)
                .HasMaxLength(1000);

            builder.Property(x => x.ImagemUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Ativo)
                .IsRequired();
        }
    }
}
