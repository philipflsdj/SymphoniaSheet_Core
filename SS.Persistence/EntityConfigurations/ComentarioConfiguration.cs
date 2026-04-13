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
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Texto)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Partitura)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.PartituraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
