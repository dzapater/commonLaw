using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class UnidadeGraphType : FederatedObjectGraphType<CriterioUnidade>
    {
        /// <summary>
        /// Unidades territoriais, também nominadas de Foro.
        /// No contexto da Distribuição de Segundo Grau utilizaremos o termo Unidade
        /// </summary>
        public UnidadeGraphType() : base("TAX")
        {
            Name = "ForoResponseMessageGraphType";
            Key(x => x.IdUnidade).Name("id");
            Key(x => x.IdTipoCadastro).Name("id_tipo_cadastro");
        }
    }
}