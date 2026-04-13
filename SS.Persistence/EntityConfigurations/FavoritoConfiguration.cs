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
    public class FavoritoConfiguration : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.ToTable("Favoritos");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Favoritos)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Partitura)
                .WithMany(x => x.Favoritos)
                .HasForeignKey(x => x.PartituraId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.UsuarioId, x.PartituraId }).IsUnique();
        }
    }
}
