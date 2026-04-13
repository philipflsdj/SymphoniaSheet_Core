using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Api.Extensions;
using SS.Application.Dispatchers.Handlers.UsuarioHandler.Command;
using SS.Application.Dispatchers.Handlers.UsuarioHandler.Query;

namespace SS.Api.Controllers
{
    [Authorize]
    public class UsuariosController : BaseController
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            var result = await _mediator.Send(new GetUsuarioByIdQuery { Id = userId.Value });

            if (result is null)
                return NotFoundResponse("Usuário não encontrado.");

            return Ok(result);
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMe([FromBody] UpdateUsuarioProfileCommand command, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            command.Id = userId.Value;

            var result = await _mediator.Send(command, cancellationToken);
            return CustomResponse(result);
        }
    }
}
