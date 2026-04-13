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
    public class PartituraTagConfiguration : IEntityTypeConfiguration<PartituraTag>
    {
        public void Configure(EntityTypeBuilder<PartituraTag> builder)
        {
            builder.ToTable("PartituraTags");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.PartituraTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.PartituraId, x.TagId }).IsUnique();
        }
    }
}
