using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace SS.Persistence.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public ArtistaRepository(SymphoniaSheetDbContext context) => _context = context;

        public async Task<Artista?> ObterPorIdAsync(Guid id) => await _context.Artistas.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<Artista>> ObterTodosAsync() => await _context.Artistas.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();

        public async Task AdicionarAsync(Artista artista)
        {
            await _context.Artistas.AddAsync(artista);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Artista artista)
        {
            _context.Artistas.Update(artista);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Artistas.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            _context.Artistas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
