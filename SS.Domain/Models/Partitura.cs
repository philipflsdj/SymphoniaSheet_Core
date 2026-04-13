using SS.Domain.Enums;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Partitura : EntityBase
    {
        public string Titulo { get; private set; } = string.Empty;
        public string? Subtitulo { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Guid ArtistaId { get; private set; }
        public string? Album { get; private set; }
        public string? Compositor { get; private set; }
        public string? Arranjador { get; private set; }
        public string? Tonalidade { get; private set; }
        public int? Bpm { get; private set; }
        public DificuldadePartitura Dificuldade { get; private set; }
        public string Idioma { get; private set; } = "pt-BR";
        public string? Descricao { get; private set; }
        public bool IsPremium { get; private set; }
        public bool IsFeatured { get; private set; }
        public bool IsVisible { get; private set; } = true;
        public StatusPartitura Status { get; private set; }
        public Guid CriadoPorUsuarioId { get; private set; }

        public virtual Categoria? Categoria { get; private set; }
        public virtual Artista? Artista { get; private set; }
        public virtual ICollection<PartituraMaterial> Materiais { get; private set; } = new List<PartituraMaterial>();
        public virtual ICollection<PartituraInstrumento> Instrumentos { get; private set; } = new List<PartituraInstrumento>();
        public virtual ICollection<PartituraTag> Tags { get; private set; } = new List<PartituraTag>();
        public virtual ICollection<Comentario> Comentarios { get; private set; } = new List<Comentario>();
        public virtual ICollection<Favorito> Favoritos { get; private set; } = new List<Favorito>();

        protected Partitura() { }

        public Partitura(
            string titulo,
            Guid categoriaId,
            Guid artistaId,
            DificuldadePartitura dificuldade,
            Guid criadoPorUsuarioId,
            bool isPremium = false)
        {
            Titulo = titulo;
            CategoriaId = categoriaId;
            ArtistaId = artistaId;
            Dificuldade = dificuldade;
            CriadoPorUsuarioId = criadoPorUsuarioId;
            IsPremium = isPremium;
            Status = StatusPartitura.Rascunho;

            Validar();
        }

        public void AtualizarDadosGerais(
            string titulo,
            string? subtitulo,
            string? album,
            string? compositor,
            string? arranjador,
            string? tonalidade,
            int? bpm,
            DificuldadePartitura dificuldade,
            string idioma,
            string? descricao,
            bool isPremium,
            bool isFeatured,
            bool isVisible)
        {
            Titulo = titulo;
            Subtitulo = subtitulo;
            Album = album;
            Compositor = compositor;
            Arranjador = arranjador;
            Tonalidade = tonalidade;
            Bpm = bpm;
            Dificuldade = dificuldade;
            Idioma = idioma;
            Descricao = descricao;
            IsPremium = isPremium;
            IsFeatured = isFeatured;
            IsVisible = isVisible;

            Validar();
        }

        public void AlterarCategoria(Guid categoriaId) => CategoriaId = categoriaId;
        public void AlterarArtista(Guid artistaId) => ArtistaId = artistaId;

        public void Publicar() => Status = StatusPartitura.Publicada;
        public void Arquivar() => Status = StatusPartitura.Arquivada;
        public void SalvarComoRascunho() => Status = StatusPartitura.Rascunho;

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Titulo))
                AddNotification("Título da partitura é obrigatório.");

            if (CategoriaId == Guid.Empty)
                AddNotification("Categoria da partitura é obrigatória.");

            if (ArtistaId == Guid.Empty)
                AddNotification("Artista da partitura é obrigatório.");

            if (CriadoPorUsuarioId == Guid.Empty)
                AddNotification("Usuário criador da partitura é obrigatório.");

            if (Bpm.HasValue && Bpm <= 0)
                AddNotification("BPM deve ser maior que zero.");
        }
    }
}
