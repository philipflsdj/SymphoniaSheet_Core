using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Configurations.DTOs.Categoria
{
    public class CategoriaPagedResultDto
    {
        public IEnumerable<CategoriaDto> Items { get; set; } = Enumerable.Empty<CategoriaDto>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
