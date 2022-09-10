using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class OrgaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<Orgao>
    {
        public OrgaoInputType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.IdTipoOrgao);
            Field(x => x.IdForo, true);
        }
    }
}