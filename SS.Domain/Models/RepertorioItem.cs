using SS.Domain.Enums;
using SS.Domain.SeedWorks;

namespace SS.Domain.Models
{
    public class RepertorioItem : EntityBase
    {
        public Guid RepertorioId { get; private set; }
        public Guid PartituraId { get; private set; }
        public string? Tom { get; private set; }
        public int? Bpm { get; private set; }
        public string? Observacoes { get; private set; }
        public int Ordem { get; private set; }
        public bool IsFavorite { get; private set; }
        public StatusRepertorioItem StatusExecucao { get; private set; }

        public virtual Repertorio? Repertorio { get; private set; }
        public virtual Partitura? Partitura { get; private set; }

        protected RepertorioItem() { }

        public RepertorioItem(Guid repertorioId, Guid partituraId, int ordem)
        {
            RepertorioId = repertorioId;
            PartituraId = partituraId;
            Ordem = ordem;
            StatusExecucao = StatusRepertorioItem.Estudando;

            Validar();
        }

        public void AtualizarExecucao(string? tom, int? bpm, string? observacoes, int ordem, StatusRepertorioItem statusExecucao)
        {
            Tom = tom;
            Bpm = bpm;
            Observacoes = observacoes;
            Ordem = ordem;
            StatusExecucao = statusExecucao;

            Validar();
        }

        public void AlternarFavorito() => IsFavorite = !IsFavorite;

        private void Validar()
        {
            ClearNotifications();

            if (RepertorioId == Guid.Empty)
                AddNotification("Repertório é obrigatório.");

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");

            if (Bpm.HasValue && Bpm <= 0)
                AddNotification("BPM deve ser maior que zero.");
        }
    }
}
