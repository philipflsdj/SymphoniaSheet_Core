using MediatR;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Handler
{
    public class PublishPartituraHandler : IRequestHandler<PublishPartituraCommand, Result>
    {
        private readonly IPartituraRepository _repository;

        public PublishPartituraHandler(IPartituraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(PublishPartituraCommand request, CancellationToken cancellationToken)
        {
            var partitura = await _repository.ObterPorIdAsync(request.Id);
            if (partitura is null)
                return Result.Fail("Partitura não encontrada.");

            partitura.Publicar();
            await _repository.AtualizarAsync(partitura);

            return Result.Ok("Partitura publicada com sucesso.");
        }
    }
}
