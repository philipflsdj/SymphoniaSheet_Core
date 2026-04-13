using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SS.Persistence.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public TagRepository(SymphoniaSheetDbContext context) => _context = context;

        public async Task<Tag?> ObterPorIdAsync(Guid id) => await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Tag?> ObterPorSlugAsync(string slug) => await _context.Tags.FirstOrDefaultAsync(x => x.Slug == slug);
        public async Task<IEnumerable<Tag>> ObterTodosAsync() => await _context.Tags.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();

        public async Task AdicionarAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            _context.Tags.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
