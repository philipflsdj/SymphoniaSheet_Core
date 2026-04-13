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
    public class RepertorioItemConfiguration : IEntityTypeConfiguration<RepertorioItem>
    {
        public void Configure(EntityTypeBuilder<RepertorioItem> builder)
        {
            builder.ToTable("RepertorioItens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tom)
                .HasMaxLength(20);

            builder.Property(x => x.Observacoes)
                .HasMaxLength(1000);

            builder.Property(x => x.StatusExecucao)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(x => x.Repertorio)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.RepertorioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Partitura)
                .WithMany()
                .HasForeignKey(x => x.PartituraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
