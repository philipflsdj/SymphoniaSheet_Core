using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Query
{
    public class GetCategoriaByIdQuery : IRequest<CategoriaDto?>
    {
        public Guid Id { get; set; }
    }
}
