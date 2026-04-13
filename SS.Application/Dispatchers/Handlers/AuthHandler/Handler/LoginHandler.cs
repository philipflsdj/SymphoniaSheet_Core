using FluentValidation;
using MediatR;
using SS.Application.Configurations.DTOs.Auth;
using SS.Application.Dispatchers.Handlers.AuthHandler.Commands;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Contracts.Services;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.AuthHandler.Handler
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<LoginCommand> _validator;
        private readonly ITokenService _tokenService;

        public LoginHandler(
            IUsuarioRepository usuarioRepository,
            IValidator<LoginCommand> validator,
            ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _validator = validator;
            _tokenService = tokenService;
        }

        public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                return Result<AuthResponseDto>.Fail(validation.Errors.Select(x => x.ErrorMessage));

            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);
            if (usuario is null)
                return Result<AuthResponseDto>.Fail("Usuário ou senha inválidos.");

            var token = _tokenService.GenerateToken(usuario);

            return Result<AuthResponseDto>.Ok(new AuthResponseDto
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role.ToString(),
                Plano = usuario.Plano.ToString()
            });
        }
    }
}
