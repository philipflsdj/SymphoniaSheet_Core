using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IInstrumentoRepository
    {
        Task<Instrumento?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Instrumento>> ObterTodosAsync();
        Task AdicionarAsync(Instrumento instrumento);
        Task AtualizarAsync(Instrumento instrumento);
        Task RemoverAsync(Guid id);
    }
}
