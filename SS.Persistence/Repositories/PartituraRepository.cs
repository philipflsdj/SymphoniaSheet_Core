using SS.Domain.Arguments;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Domain.SeedWorks;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Persistence.Repositories
{
    public class PartituraRepository : IPartituraRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public PartituraRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Partitura?> ObterPorIdAsync(Guid id)
            =>   await _context.Partituras
                .Include(x => x.Categoria)
                .Include(x => x.Artista)
                .Include(x => x.Materiais)
                .ThenInclude(x => x.Arquivo)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<PagedResult<Partitura>> BuscarAsync(PartituraFiltro filtro)
        {
            var query = _context.Partituras
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Include(x => x.Artista)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Texto))
                query = query.Where(x =>
                    x.Titulo.Contains(filtro.Texto) ||
                    (x.Subtitulo != null && x.Subtitulo.Contains(filtro.Texto)));

            if (filtro.CategoriaId.HasValue)
                query = query.Where(x => x.CategoriaId == filtro.CategoriaId.Value);

            if (filtro.ArtistaId.HasValue)
                query = query.Where(x => x.ArtistaId == filtro.ArtistaId.Value);

            if (filtro.IsPremium.HasValue)
                query = query.Where(x => x.IsPremium == filtro.IsPremium.Value);

            if (filtro.IsVisible.HasValue)
                query = query.Where(x => x.IsVisible == filtro.IsVisible.Value);

            if (filtro.Status.HasValue)
                query = query.Where(x => x.Status == filtro.Status.Value);

            if (filtro.Dificuldade.HasValue)
                query = query.Where(x => x.Dificuldade == filtro.Dificuldade.Value);

            var total = await query.LongCountAsync();

            var items = await query
                .OrderByDescending(x => x.IsFeatured)
                .ThenBy(x => x.Titulo)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return new PagedResult<Partitura>
            {
                Items = items,
                PageNumber = filtro.Pagina,
                PageSize = filtro.TamanhoPagina,
                TotalCount = total
            };
        }

        public async Task<IEnumerable<Partitura>> ObterRecentesAsync(int quantidade)
            => await _context.Partituras
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Take(quantidade)
                .ToListAsync();

        public async Task<IEnumerable<Partitura>> ObterDestaquesAsync(int quantidade)
            => await _context.Partituras
                .AsNoTracking()
                .Where(x => x.IsFeatured)
                .OrderBy(x => x.Titulo)
                .Take(quantidade)
                .ToListAsync();

        public async Task AdicionarAsync(Partitura partitura)
        {
            await _context.Partituras.AddAsync(partitura);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Partitura partitura)
        {
            _context.Partituras.Update(partitura);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Partituras.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;

            _context.Partituras.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
