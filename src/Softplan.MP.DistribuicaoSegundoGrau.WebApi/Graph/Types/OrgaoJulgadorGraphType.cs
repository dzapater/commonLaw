using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class OrgaoJulgadorGraphType : FederatedObjectGraphType<CriterioOrgaoJulgador>
    {
        /// <summary>
        /// Para o contexto de segundo grau, utiliza-se o termo Órgão Julgador ao invés de Vara
        /// </summary>
        public OrgaoJulgadorGraphType() : base("TAX")
        {
            Name = "VaraGraphType";
            Key(x => x.IdOrgaoJulgador).Name("id");
            Key(x => x.IdTipoCadastro).Name("id_tipo_cadastro");
            Key(x => x.IdUnidade).Name("id_foro");
        }
    }
}