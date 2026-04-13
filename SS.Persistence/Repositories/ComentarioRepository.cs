using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Persistence.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public ComentarioRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Comentario?> ObterPorIdAsync(Guid id)
            => await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Comentario>> ObterPorPartituraAsync(Guid partituraId)
            => await _context.Comentarios
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Where(x => x.PartituraId == partituraId)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

        public async Task AdicionarAsync(Comentario comentario)
        {
            await _context.Comentarios.AddAsync(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;

            _context.Comentarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
