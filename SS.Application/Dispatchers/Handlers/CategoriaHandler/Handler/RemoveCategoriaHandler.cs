using MediatR;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Handler
{
    public class RemoveCategoriaHandler : IRequestHandler<RemoveCategoriaCommand, Result>
    {
        private readonly ICategoriaRepository _repository;

        public RemoveCategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _repository.ObterPorIdAsync(request.Id);
            if (categoria is null)
                return Result.Fail("Categoria não encontrada.");

            await _repository.RemoverAsync(request.Id);

            return Result.Ok("Categoria removida com sucesso.");
        }
    }
}
