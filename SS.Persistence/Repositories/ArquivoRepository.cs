using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SS.Persistence.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public ArquivoRepository(SymphoniaSheetDbContext context) => _context = context;

        public async Task<Arquivo?> ObterPorIdAsync(Guid id) => await _context.Arquivos.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AdicionarAsync(Arquivo arquivo)
        {
            await _context.Arquivos.AddAsync(arquivo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Arquivo arquivo)
        {
            _context.Arquivos.Update(arquivo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Arquivos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            _context.Arquivos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
