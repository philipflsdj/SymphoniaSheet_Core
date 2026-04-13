using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Api.Extensions;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Command;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Query;
using SS.Domain.Arguments;

namespace SS.Api.Controllers
{
    [Authorize]
    public class PartiturasController : BaseController
    {
        private readonly IMediator _mediator;

        public PartiturasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(
            [FromQuery] string? texto,
            [FromQuery] Guid? categoriaId,
            [FromQuery] Guid? artistaId,
            [FromQuery] bool? isPremium,
            [FromQuery] bool? isVisible,
            [FromQuery] int? status,
            [FromQuery] int? dificuldade,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 10)
        {
            var query = new SearchPartiturasQuery
            {
                Filtro = new PartituraFiltro
                {
                    Texto = texto,
                    CategoriaId = categoriaId,
                    ArtistaId = artistaId,
                    IsPremium = isPremium,
                    IsVisible = isVisible,
                    Status = status.HasValue ? (SS.Domain.Enums.StatusPartitura)status.Value : null,
                    Dificuldade = dificuldade.HasValue ? (SS.Domain.Enums.DificuldadePartitura)dificuldade.Value : null,
                    Pagina = pagina,
                    TamanhoPagina = tamanhoPagina
                }
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPartituraByIdQuery { Id = id });

            if (result is null)
                return NotFoundResponse("Partitura não encontrada.");

            return Ok(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPartituraCommand command, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            command.CriadoPorUsuarioId = userId.Value;

            var result = await _mediator.Send(command, cancellationToken);
            return CustomResponse(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePartituraCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return CustomResponse(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPatch("{id:guid}/publish")]
        public async Task<IActionResult> Publish(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new PublishPartituraCommand { Id = id }, cancellationToken);
            return CustomResponse(result);
        }
    }
}
