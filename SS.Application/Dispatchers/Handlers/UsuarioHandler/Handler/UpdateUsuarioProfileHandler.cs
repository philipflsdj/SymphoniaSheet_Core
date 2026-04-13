using AutoMapper;
using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Usuario;
using SS.Application.Dispatchers.Handlers.UsuarioHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.UsuarioHandler.Handler
{
    public class UpdateUsuarioProfileHandler : IRequestHandler<UpdateUsuarioProfileCommand, Result<UsuarioDto>>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<UpdateUsuarioProfileCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateUsuarioProfileHandler(
            IUsuarioRepository repository,
            IValidator<UpdateUsuarioProfileCommand> validator,
            IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<UsuarioDto>> Handle(UpdateUsuarioProfileCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<UsuarioDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var usuario = await _repository.ObterPorIdAsync(request.Id);
            if (usuario is null)
                return Result<UsuarioDto>.Fail("Usuário não encontrado.");

            usuario.AtualizarPerfil(request.Nome, request.AvatarUrl);

            if (!usuario.IsValid)
                return Result<UsuarioDto>.Fail(usuario.Notifications);

            await _repository.AtualizarAsync(usuario);

            return Result<UsuarioDto>.Ok(_mapper.Map<UsuarioDto>(usuario), "Perfil atualizado com sucesso.");
        }
    }
}
