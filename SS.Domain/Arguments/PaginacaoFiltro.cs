using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Arguments
{
    public class PaginacaoFiltro
    {
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }
}
