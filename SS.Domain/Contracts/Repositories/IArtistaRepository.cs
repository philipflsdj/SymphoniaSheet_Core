using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IArtistaRepository
    {
        Task<Artista?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Artista>> ObterTodosAsync();
        Task AdicionarAsync(Artista artista);
        Task AtualizarAsync(Artista artista);
        Task RemoverAsync(Guid id);
    }
}
