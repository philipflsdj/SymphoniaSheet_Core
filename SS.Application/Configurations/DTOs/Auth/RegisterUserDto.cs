using SS.Domain.Enums;


namespace SS.Application.Configurations.DTOs.Auth
{
    public class RegisterUserDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public RoleUsuario Role { get; set; } = RoleUsuario.Free;
    }
}
