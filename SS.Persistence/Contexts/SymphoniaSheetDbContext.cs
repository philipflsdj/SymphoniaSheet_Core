using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SS.Domain.Models;
using SS.Persistence.Services.Identity;


namespace SS.Persistence.Contexts
{
    public class SymphoniaSheetDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Artista> Artistas => Set<Artista>();
        public DbSet<Arquivo> Arquivos => Set<Arquivo>();
        public DbSet<Instrumento> Instrumentos => Set<Instrumento>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Partitura> Partituras => Set<Partitura>();
        public DbSet<PartituraMaterial> PartituraMateriais => Set<PartituraMaterial>();
        public DbSet<PartituraInstrumento> PartituraInstrumentos => Set<PartituraInstrumento>();
        public DbSet<PartituraTag> PartituraTags => Set<PartituraTag>();
        public DbSet<Favorito> Favoritos => Set<Favorito>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<Repertorio> Repertorios => Set<Repertorio>();
        public DbSet<RepertorioItem> RepertorioItens => Set<RepertorioItem>();

        public SymphoniaSheetDbContext(DbContextOptions<SymphoniaSheetDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SymphoniaSheetDbContext).Assembly);
        }
    }
}
