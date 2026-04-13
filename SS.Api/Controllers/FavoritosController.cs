using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Api.Extensions;
using SS.Application.Dispatchers.Handlers.FavoritosHandler.Command;

namespace SS.Api.Controllers
{
    [Authorize]
    public class FavoritosController : BaseController
    {
        private readonly IMediator _mediator;

        public FavoritosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{partituraId:guid}")]
        public async Task<IActionResult> Add(Guid partituraId, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            var result = await _mediator.Send(new AddFavoritoCommand
            {
                UsuarioId = userId.Value,
                PartituraId = partituraId
            }, cancellationToken);

            return CustomResponse(result);
        }

        [HttpDelete("{partituraId:guid}")]
        public async Task<IActionResult> Remove(Guid partituraId, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            var result = await _mediator.Send(new RemoveFavoritoCommand
            {
                UsuarioId = userId.Value,
                PartituraId = partituraId
            }, cancellationToken);

            return CustomResponse(result);
        }
    }
}
