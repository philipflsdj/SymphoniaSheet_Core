using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;

namespace SS.Persistence.EntityConfigurations
{
    public class InstrumentoConfiguration : IEntityTypeConfiguration<Instrumento>
    {
        public void Configure(EntityTypeBuilder<Instrumento> builder)
        {
            builder.ToTable("Instrumentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}
