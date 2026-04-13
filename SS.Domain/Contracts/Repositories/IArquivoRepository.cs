using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IArquivoRepository
    {
        Task<Arquivo?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Arquivo arquivo);
        Task AtualizarAsync(Arquivo arquivo);
        Task RemoverAsync(Guid id);
    }
}
