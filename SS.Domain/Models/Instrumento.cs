using SS.Domain.SeedWorks;

namespace SS.Domain.Models
{
    public class Instrumento : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public bool Ativo { get; private set; } = true;

        public virtual ICollection<PartituraInstrumento> PartituraInstrumentos { get; private set; } = new List<PartituraInstrumento>();

        protected Instrumento() { }

        public Instrumento(string nome)
        {
            Nome = nome;
            Validar();
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome do instrumento é obrigatório.");
        }
    }
}
