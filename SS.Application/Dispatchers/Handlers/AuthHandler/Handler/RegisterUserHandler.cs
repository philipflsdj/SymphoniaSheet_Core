using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Auth;
using SS.Application.Configurations.Interfaces;
using SS.Application.Dispatchers.Handlers.AuthHandler.Commands;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Contracts.Services;
using SS.Domain.Enums;
using SS.Domain.Models;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.AuthHandler.Handler
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<AuthResponseDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IValidator<RegisterUserCommand> _validator;
        private readonly IMediatorHandler _mediatorHandler;

        public RegisterUserHandler(
            IUsuarioRepository usuarioRepository,
            ITokenService tokenService,
            IValidator<RegisterUserCommand> validator,
            IMediatorHandler mediatorHandler)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _validator = validator;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Result<AuthResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<AuthResponseDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
            if (usuarioExistente is not null)
                return Result<AuthResponseDto>.Fail("Já existe um usuário com este e-mail.");

            var usuario = new Usuario(
                request.Nome,
                request.Email,
                request.Role,
                request.Role == RoleUsuario.Free ? PlanoUsuario.Free : PlanoUsuario.Premium);

            if (!usuario.IsValid)
                return Result<AuthResponseDto>.Fail(usuario.Notifications);

            await _usuarioRepository.AdicionarAsync(usuario);

            var token = _tokenService.GenerateToken(usuario);

            return Result<AuthResponseDto>.Ok(new AuthResponseDto
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString(),
                Plano = usuario.Plano.ToString()
            }, "Usuário registrado com sucesso.");
        }
    }
}
