using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Shared
{
    public static class DomainMessages
    {
        public const string CampoObrigatorio = "O campo é obrigatório.";
        public const string RegistroNaoEncontrado = "Registro não encontrado.";
        public const string UsuarioSemPermissao = "Usuário sem permissão para realizar esta operação.";
        public const string PartituraJaFavoritada = "A partitura já foi favoritada por este usuário.";
        public const string ComentarioInvalido = "Comentário inválido.";
        public const string CategoriaJaExiste = "Já existe uma categoria com este nome.";
    }
}
