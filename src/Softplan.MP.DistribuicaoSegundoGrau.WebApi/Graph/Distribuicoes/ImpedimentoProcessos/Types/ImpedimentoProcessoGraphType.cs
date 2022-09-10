using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos.Types
{
    public class ImpedimentoProcessoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<ImpedimentoProcesso>
    {
        public ImpedimentoProcessoGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdProcesso);
            Field(x => x.IdImpedimento);
            Field(x => x.IdVaga);
            Field(x => x.Motivo);
            Field(x => x.Vaga, true, typeof(VagaGraphType));
            Field(x => x.Mensagens, true);
        }
    }
}