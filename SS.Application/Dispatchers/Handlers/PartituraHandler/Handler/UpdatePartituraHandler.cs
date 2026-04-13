using AutoMapper;
using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
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
    public class UpdatePartituraHandler : IRequestHandler<UpdatePartituraCommand, Result<PartituraDto>>
    {
        private readonly IPartituraRepository _repository;
        private readonly IValidator<UpdatePartituraCommand> _validator;
        private readonly IMapper _mapper;

        public UpdatePartituraHandler(
            IPartituraRepository repository,
            IValidator<UpdatePartituraCommand> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<PartituraDto>> Handle(UpdatePartituraCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<PartituraDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var partitura = await _repository.ObterPorIdAsync(request.Id);
            if (partitura is null)
                return Result<PartituraDto>.Fail("Partitura não encontrada.");

            partitura.AtualizarDadosGerais(
                request.Titulo,
                request.Subtitulo,
                request.Album,
                request.Compositor,
                request.Arranjador,
                request.Tonalidade,
                request.Bpm,
                request.Dificuldade,
                request.Idioma,
                request.Descricao,
                request.IsPremium,
                request.IsFeatured,
                request.IsVisible);

            if (!partitura.IsValid)
                return Result<PartituraDto>.Fail(partitura.Notifications);

            await _repository.AtualizarAsync(partitura);

            return Result<PartituraDto>.Ok(_mapper.Map<PartituraDto>(partitura), "Partitura atualizada com sucesso.");
        }
    }
}
