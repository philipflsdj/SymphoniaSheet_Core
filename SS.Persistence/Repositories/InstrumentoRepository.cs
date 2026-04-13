using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SS.Persistence.Repositories
{
    public class InstrumentoRepository : IInstrumentoRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public InstrumentoRepository(SymphoniaSheetDbContext context) => _context = context;

        public async Task<Instrumento?> ObterPorIdAsync(Guid id) => await _context.Instrumentos.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<Instrumento>> ObterTodosAsync() => await _context.Instrumentos.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();

        public async Task AdicionarAsync(Instrumento instrumento)
        {
            await _context.Instrumentos.AddAsync(instrumento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Instrumento instrumento)
        {
            _context.Instrumentos.Update(instrumento);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Instrumentos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            _context.Instrumentos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
