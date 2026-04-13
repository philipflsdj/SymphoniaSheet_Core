using Microsoft.EntityFrameworkCore;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Persistence.Contexts;


namespace SS.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SymphoniaSheetDbContext _context;

        public UsuarioRepository(SymphoniaSheetDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorIdAsync(Guid id)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Usuario?> ObterPorEmailAsync(string email)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
            => await _context.Usuarios.AsNoTracking().ToListAsync();

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var entity = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
