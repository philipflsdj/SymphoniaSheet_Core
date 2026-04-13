using AutoMapper;
using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Domain.SeedWorks;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Handler
{
    public class AddCategoriaHandler : IRequestHandler<AddCategoriaCommand, Result<CategoriaDto>>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IValidator<AddCategoriaCommand> _validator;
        private readonly IMapper _mapper;

        public AddCategoriaHandler(
            ICategoriaRepository repository,
            IValidator<AddCategoriaCommand> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<CategoriaDto>> Handle(AddCategoriaCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<CategoriaDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var existente = await _repository.ObterPorNomeAsync(request.Nome);
            if (existente is not null)
                return Result<CategoriaDto>.Fail("Já existe uma categoria com este nome.");

            var categoria = new Categoria(request.Nome, request.Descricao, request.Icone, request.OrdemExibicao);

            if (!categoria.IsValid)
                return Result<CategoriaDto>.Fail(categoria.Notifications);

            await _repository.AdicionarAsync(categoria);

            return Result<CategoriaDto>.Ok(_mapper.Map<CategoriaDto>(categoria), "Categoria criada com sucesso.");
        }
    }
}
