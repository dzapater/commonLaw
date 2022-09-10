using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types
{
    public class AreaAtuacaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<AreaAtuacao>
    {
        public AreaAtuacaoInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id, true);
        }
    }
}