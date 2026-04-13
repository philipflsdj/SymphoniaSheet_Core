using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;

namespace SS.Persistence.EntityConfigurations
{
    public class PartituraInstrumentoConfiguration : IEntityTypeConfiguration<PartituraInstrumento>
    {
        public void Configure(EntityTypeBuilder<PartituraInstrumento> builder)
        {
            builder.ToTable("PartituraInstrumentos");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Instrumento)
                .WithMany(x => x.PartituraInstrumentos)
                .HasForeignKey(x => x.InstrumentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.PartituraId, x.InstrumentoId }).IsUnique();
        }
    }
}
