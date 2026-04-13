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
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public FavoritoRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Favorito?> ObterAsync(Guid usuarioId, Guid partituraId)
            => await _context.Favoritos.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.PartituraId == partituraId);

        public async Task<IEnumerable<Favorito>> ObterPorUsuarioAsync(Guid usuarioId)
            => await _context.Favoritos
                .AsNoTracking()
                .Include(x => x.Partitura)
                .Where(x => x.UsuarioId == usuarioId)
                .ToListAsync();

        public async Task AdicionarAsync(Favorito favorito)
        {
            await _context.Favoritos.AddAsync(favorito);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid usuarioId, Guid partituraId)
        {
            var entity = await _context.Favoritos.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.PartituraId == partituraId);
            if (entity is null) return;

            _context.Favoritos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
