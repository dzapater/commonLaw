using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types
{
    public class ExcecaoVagaFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<ExcecaoVagaFilter>
    {
        public ExcecaoVagaFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
            Field(x => x.IdVaga);
            Field(x => x.IdClasse, true);
            Field(x => x.IdOrgaoJulgador, true);
            Field(x => x.IdAssunto, true);
            Field(x => x.IdEspecialidade, true);
            Field(x => x.IdOrigem, true);
            Field(x => x.IdUnidade, true);
            Field(x => x.IdTarja, true);
        }
    }
}