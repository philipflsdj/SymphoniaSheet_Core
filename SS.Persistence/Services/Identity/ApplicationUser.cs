using Microsoft.AspNetCore.Identity;


namespace SS.Persistence.Services.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
    }
}
