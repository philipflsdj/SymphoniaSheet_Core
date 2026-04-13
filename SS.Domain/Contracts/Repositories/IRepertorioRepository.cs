using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IRepertorioRepository
    {
        Task<Repertorio?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Repertorio>> ObterPorUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(Repertorio repertorio);
        Task AtualizarAsync(Repertorio repertorio);
        Task RemoverAsync(Guid id);
    }
}
