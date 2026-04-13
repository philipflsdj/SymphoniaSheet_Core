using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Arguments
{
    public class CategoriaFiltro : PaginacaoFiltro
    {
        public string? Nome { get; set; }
        public bool? Ativa { get; set; }
    }
}
