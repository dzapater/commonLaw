using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types
{
    public class ExcecaoVagaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<ExcecaoVaga>
    {
        public ExcecaoVagaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.IdVaga);
            Field(x => x.IdAssunto, true);
            Field(x => x.IdClasse, true);
            Field(x => x.IdEspecialidade, true);
            Field(x => x.IdOrgaoJulgador, true);
            Field(x => x.IdOrigem, true);
            Field(x => x.IdUnidade, true);
            Field(x => x.Mensagens, true);
        }
    }
}
