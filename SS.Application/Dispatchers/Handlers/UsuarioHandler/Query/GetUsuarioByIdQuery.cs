using MediatR;
using SS.Application.Configurations.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.UsuarioHandler.Query
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto?>
    {
        public Guid Id { get; set; }
    }
}
