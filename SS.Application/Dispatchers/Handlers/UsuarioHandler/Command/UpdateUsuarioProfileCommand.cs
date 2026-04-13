using MediatR;
using SS.Application.Configurations.DTOs.Usuario;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.UsuarioHandler.Command
{
    public class UpdateUsuarioProfileCommand : IRequest<Result<UsuarioDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
    }
}
