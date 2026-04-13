using Microsoft.EntityFrameworkCore;
using SS.Domain.Arguments;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Domain.SeedWorks;
using SS.Persistence.Contexts;


namespace SS.Persistence.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public CategoriaRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria?> ObterPorIdAsync(Guid id)
            => await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Categoria?> ObterPorNomeAsync(string nome)
            => await _context.Categorias.FirstOrDefaultAsync(x => x.Nome == nome);

        public async Task<IEnumerable<Categoria>> ObterAtivasAsync()
            => await _context.Categorias.AsNoTracking().Where(x => x.Ativa).OrderBy(x => x.OrdemExibicao).ToListAsync();

        public async Task<PagedResult<Categoria>> ObterPaginadoAsync(CategoriaFiltro filtro)
        {
            var query = _context.Categorias.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
                query = query.Where(x => x.Nome.Contains(filtro.Nome));

            if (filtro.Ativa.HasValue)
                query = query.Where(x => x.Ativa == filtro.Ativa.Value);

            var total = await query.LongCountAsync();

            var items = await query
                .OrderBy(x => x.OrdemExibicao)
                .ThenBy(x => x.Nome)
                .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
                .Take(filtro.TamanhoPagina)
                .ToListAsync();

            return new PagedResult<Categoria>
            {
                Items = items,
                PageNumber = filtro.Pagina,
                PageSize = filtro.TamanhoPagina,
                TotalCount = total
            };
        }

        public async Task AdicionarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;

            _context.Categorias.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
