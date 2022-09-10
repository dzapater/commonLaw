using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class EspecialidadeInputType : Softplan.Common.Graph.Types.InputObjectGraphType<CriterioEspecialidade>
    {
        public EspecialidadeInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.IdEspecialidade);
            Field(x => x.Id, true);
        }
    }
}