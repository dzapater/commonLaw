using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos.Types
{
    public class CreateImpedimentoProcessoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<ImpedimentoProcesso>
    {
        public CreateImpedimentoProcessoInputType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.IdVaga);
            Field(x => x.Motivo);
        }
    }
}