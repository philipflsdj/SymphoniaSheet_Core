using SS.Domain.Enums;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string? AvatarUrl { get; private set; }
        public RoleUsuario Role { get; private set; }
        public PlanoUsuario Plano { get; private set; }
        public StatusUsuario Status { get; private set; }

        public virtual ICollection<Favorito> Favoritos { get; private set; } = new List<Favorito>();
        public virtual ICollection<Comentario> Comentarios { get; private set; } = new List<Comentario>();
        public virtual ICollection<Repertorio> Repertorios { get; private set; } = new List<Repertorio>();

        protected Usuario() { }

        public Usuario(string nome, string email, RoleUsuario role, PlanoUsuario plano)
        {
            Nome = nome;
            Email = email;
            Role = role;
            Plano = plano;
            Status = StatusUsuario.Ativo;

            Validar();
        }

        public void AtualizarPerfil(string nome, string? avatarUrl)
        {
            Nome = nome;
            AvatarUrl = avatarUrl;
            Validar();
        }

        public void AlterarPlano(PlanoUsuario plano) => Plano = plano;

        public void AlterarStatus(StatusUsuario status) => Status = status;

        public bool EhAdminOuOwner() => Role == RoleUsuario.Admin || Role == RoleUsuario.Owner;

        public bool TemAcessoPremium() => Plano == PlanoUsuario.Premium || Role == RoleUsuario.Admin || Role == RoleUsuario.Owner;

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome do usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(Email))
                AddNotification("E-mail do usuário é obrigatório.");
        }
    }
}
