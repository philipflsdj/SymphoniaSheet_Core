using AutoMapper;
using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Handler
{
    public class UpdateCategoriaHandler : IRequestHandler<UpdateCategoriaCommand, Result<CategoriaDto>>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IValidator<UpdateCategoriaCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateCategoriaHandler(
            ICategoriaRepository repository,
            IValidator<UpdateCategoriaCommand> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<CategoriaDto>> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<CategoriaDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var categoria = await _repository.ObterPorIdAsync(request.Id);
            if (categoria is null)
                return Result<CategoriaDto>.Fail("Categoria não encontrada.");

            categoria.Atualizar(request.Nome, request.Descricao, request.Icone, request.OrdemExibicao);

            if (!categoria.IsValid)
                return Result<CategoriaDto>.Fail(categoria.Notifications);

            await _repository.AtualizarAsync(categoria);

            return Result<CategoriaDto>.Ok(_mapper.Map<CategoriaDto>(categoria), "Categoria atualizada com sucesso.");
        }
    }
}
