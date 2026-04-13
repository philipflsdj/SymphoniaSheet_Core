using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;

namespace SS.Persistence.EntityConfigurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .HasMaxLength(500);

            builder.Property(x => x.Icone)
                .HasMaxLength(100);

            builder.Property(x => x.Ativa)
                .IsRequired();

            builder.Property(x => x.OrdemExibicao)
                .IsRequired();

            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}
