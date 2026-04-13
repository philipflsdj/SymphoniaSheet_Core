using MediatR;
using SS.Application.Configurations.DTOs.Auth;
using SS.Domain.SeedWorks;

namespace SS.Application.Dispatchers.Handlers.AuthHandler.Commands
{
    public class LoginCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
