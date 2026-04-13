using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(Guid id);
    }
}
