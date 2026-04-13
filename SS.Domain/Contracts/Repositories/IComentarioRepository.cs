using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IComentarioRepository
    {
        Task<Comentario?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Comentario>> ObterPorPartituraAsync(Guid partituraId);
        Task AdicionarAsync(Comentario comentario);
        Task AtualizarAsync(Comentario comentario);
        Task RemoverAsync(Guid id);
    }
}
