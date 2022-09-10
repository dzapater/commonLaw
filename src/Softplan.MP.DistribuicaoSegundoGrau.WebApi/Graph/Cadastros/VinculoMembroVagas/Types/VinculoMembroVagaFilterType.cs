using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class VinculoMembroVagaFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<VinculoMembroVagaFilter>
    {
        public VinculoMembroVagaFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.PageNumber,true);
            Field(x => x.PageSize,true);
            Field(x => x.Busca, true);
            Field(x => x.Id,true);
            Field(x => x.IdVaga,true);
            Field(x => x.IdMembro,true);
            Field(x => x.IdMotivoMembroVaga,true);
            Field(x => x.SomenteAtivo, true);
        }
    }
}