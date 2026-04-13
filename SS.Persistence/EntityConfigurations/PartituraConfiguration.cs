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
    public class PartituraConfiguration : IEntityTypeConfiguration<Partitura>
    {
        public void Configure(EntityTypeBuilder<Partitura> builder)
        {
            builder.ToTable("Partituras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Subtitulo)
                .HasMaxLength(200);

            builder.Property(x => x.Album)
                .HasMaxLength(150);

            builder.Property(x => x.Compositor)
                .HasMaxLength(150);

            builder.Property(x => x.Arranjador)
                .HasMaxLength(150);

            builder.Property(x => x.Tonalidade)
                .HasMaxLength(20);

            builder.Property(x => x.Idioma)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Descricao)
                .HasMaxLength(4000);

            builder.Property(x => x.Dificuldade)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.IsPremium).IsRequired();
            builder.Property(x => x.IsFeatured).IsRequired();
            builder.Property(x => x.IsVisible).IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Partituras)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Artista)
                .WithMany(x => x.Partituras)
                .HasForeignKey(x => x.ArtistaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Materiais)
                .WithOne(x => x.Partitura)
                .HasForeignKey(x => x.PartituraId);

            builder.HasMany(x => x.Instrumentos)
                .WithOne(x => x.Partitura)
                .HasForeignKey(x => x.PartituraId);

            builder.HasMany(x => x.Tags)
                .WithOne(x => x.Partitura)
                .HasForeignKey(x => x.PartituraId);

            builder.HasMany(x => x.Comentarios)
                .WithOne(x => x.Partitura)
                .HasForeignKey(x => x.PartituraId);

            builder.HasMany(x => x.Favoritos)
                .WithOne(x => x.Partitura)
                .HasForeignKey(x => x.PartituraId);
        }
    }
}
