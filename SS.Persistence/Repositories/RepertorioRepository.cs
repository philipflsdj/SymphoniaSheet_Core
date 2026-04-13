using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SS.Persistence.Repositories
{
    public class RepertorioRepository : IRepertorioRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public RepertorioRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Repertorio?> ObterPorIdAsync(Guid id)
            => await _context.Repertorios
                .Include(x => x.Itens)
                .ThenInclude(x => x.Partitura)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Repertorio>> ObterPorUsuarioAsync(Guid usuarioId)
            => await _context.Repertorios
                .AsNoTracking()
                .Include(x => x.Itens)
                .Where(x => x.UsuarioId == usuarioId)
                .OrderBy(x => x.Nome)
                .ToListAsync();

        public async Task AdicionarAsync(Repertorio repertorio)
        {
            await _context.Repertorios.AddAsync(repertorio);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Repertorio repertorio)
        {
            _context.Repertorios.Update(repertorio);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Repertorios.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;

            _context.Repertorios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
