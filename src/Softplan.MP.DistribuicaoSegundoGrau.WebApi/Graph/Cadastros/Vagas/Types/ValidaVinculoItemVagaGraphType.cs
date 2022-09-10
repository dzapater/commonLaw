using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class ValidaVinculoItemVagaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<ValidaVinculoItemVaga>
    {
        public ValidaVinculoItemVagaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Status, true);
            Field(x => x.Mensagens, true);            
        }
    }
}
