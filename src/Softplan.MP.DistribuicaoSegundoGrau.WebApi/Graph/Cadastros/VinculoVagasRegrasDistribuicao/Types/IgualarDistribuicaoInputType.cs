using Softplan.Common.Graph.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class IgualarDistribuicaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<Domain.Cadastros.VinculoVagasRegrasDistribuicao.Compensacao>
    {
        public IgualarDistribuicaoInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdRegraDistribuicao);
            Field(x => x.Motivo);
        }
    }

}