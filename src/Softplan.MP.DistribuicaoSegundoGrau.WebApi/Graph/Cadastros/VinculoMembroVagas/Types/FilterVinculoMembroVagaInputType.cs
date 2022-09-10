using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class FilterVinculoMembroVagaInputType : CreateVinculoMembroVagaInputType
    {
        public FilterVinculoMembroVagaInputType(IDescriptionProvider provider) :
            base(provider)
        {            
            Field(x => x.Id, true);            
        }
    }
}