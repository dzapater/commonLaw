using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class OrgaoGraphType : FederatedObjectGraphType<Orgao>
    {
        /// <summary>
        /// No contexto de segundo grau, utilizaremos o termo Orgao para designar o Local.
        /// </summary>
        public OrgaoGraphType() : base("USR")
        {
            Name = "LocalType";
            Key(x => x.Id).Name("id_local");
            Key(x => x.IdTipoOrgao).Name("id_tipo_local");
            Key(x => x.IdForo).Name("id_foro");
        }
    }
}