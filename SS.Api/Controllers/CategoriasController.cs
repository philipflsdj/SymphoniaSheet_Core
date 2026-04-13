using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Command;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Query;
using SS.Domain.Arguments;

namespace SS.Api.Controllers
{
    [Authorize]
    public class CategoriasController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] string? nome, [FromQuery] bool? ativa, [FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            var query = new GetCategoriasPagedQuery
            {
                Filtro = new CategoriaFiltro
                {
                    Nome = nome,
                    Ativa = ativa,
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
            var result = await _mediator.Send(new GetCategoriaByIdQuery { Id = id });

            if (result is null)
                return NotFoundResponse("Categoria não encontrada.");

            return Ok(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoriaCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CustomResponse(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCategoriaCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return CustomResponse(result);
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RemoveCategoriaCommand { Id = id }, cancellationToken);
            return CustomResponse(result);
        }
    }
}
