using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class MotivoMembroVagaFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<MotivoMembroVagaFilter>
    {
        public MotivoMembroVagaFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
            Field(x => x.Busca, true);
            Field(x => x.Ativo, true);
            Field(x => x.Id, true);
        }
    }
}