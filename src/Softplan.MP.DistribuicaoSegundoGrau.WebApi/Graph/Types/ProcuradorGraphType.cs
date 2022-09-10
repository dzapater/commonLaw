using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class ProcuradorTitularGraphType : FederatedObjectGraphType<ProcuradorTitular>
    {
        /// <summary>
        /// Usuario é o termo utilizado para designar tanto procuradores, quanto promotores.
        /// Procurador é o integrante do MP que atua na Segunda Instância
        /// </summary>
        public ProcuradorTitularGraphType() : base("USR")
        {
            Name = "UsuarioType";
            Key(x => x.Id).Name("id");
        }
    }
}