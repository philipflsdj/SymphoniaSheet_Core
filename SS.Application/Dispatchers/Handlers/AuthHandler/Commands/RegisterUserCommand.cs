using MediatR;
using SS.Application.Configurations.DTOs.Auth;
using SS.Domain.Enums;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.AuthHandler.Commands
{
    public class RegisterUserCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public RoleUsuario Role { get; set; } = RoleUsuario.Free;
    }
}
