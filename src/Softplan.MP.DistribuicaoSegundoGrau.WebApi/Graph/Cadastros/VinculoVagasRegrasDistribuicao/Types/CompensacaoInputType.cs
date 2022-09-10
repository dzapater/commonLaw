using GraphQL.Types;
using Softplan.Common.Graph.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class CompensacaoInputType : IgualarDistribuicaoInputType
    {
        public CompensacaoInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Vagas, type: typeof(ListGraphType<VagaCompensacaoInputType>));
        }
    }

}