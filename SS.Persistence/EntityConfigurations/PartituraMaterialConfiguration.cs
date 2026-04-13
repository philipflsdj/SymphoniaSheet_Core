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
    public class PartituraMaterialConfiguration : IEntityTypeConfiguration<PartituraMaterial>
    {
        public void Configure(EntityTypeBuilder<PartituraMaterial> builder)
        {
            builder.ToTable("PartituraMateriais");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TipoMaterial)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(x => x.Ordem)
                .IsRequired();

            builder.HasOne(x => x.Arquivo)
                .WithMany()
                .HasForeignKey(x => x.ArquivoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
