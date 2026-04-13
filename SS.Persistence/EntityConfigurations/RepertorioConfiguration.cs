using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Persistence.EntityConfigurations
{
    public class RepertorioConfiguration : IEntityTypeConfiguration<Repertorio>
    {
        public void Configure(EntityTypeBuilder<Repertorio> builder)
        {
            builder.ToTable("Repertorios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Descricao)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Repertorios)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
