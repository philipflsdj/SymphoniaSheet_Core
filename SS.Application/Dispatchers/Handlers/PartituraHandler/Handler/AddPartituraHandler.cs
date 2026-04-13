using AutoMapper;
using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Handler
{
    public class AddPartituraHandler : IRequestHandler<AddPartituraCommand, Result<PartituraDto>>
    {
        private readonly IPartituraRepository _repository;
        private readonly IValidator<AddPartituraCommand> _validator;
        private readonly IMapper _mapper;

        public AddPartituraHandler(
            IPartituraRepository repository,
            IValidator<AddPartituraCommand> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<PartituraDto>> Handle(AddPartituraCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<PartituraDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var partitura = new Partitura(
                request.Titulo,
                request.CategoriaId,
                request.ArtistaId,
                request.Dificuldade,
                request.CriadoPorUsuarioId,
                request.IsPremium);

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

            await _repository.AdicionarAsync(partitura);

            return Result<PartituraDto>.Ok(_mapper.Map<PartituraDto>(partitura), "Partitura criada com sucesso.");
        }
    }
}
