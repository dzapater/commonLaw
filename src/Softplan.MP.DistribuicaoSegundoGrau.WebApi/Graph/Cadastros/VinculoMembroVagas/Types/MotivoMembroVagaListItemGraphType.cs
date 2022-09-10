using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class MotivoMembroVagaListItemGraphType: Softplan.Common.Graph.Types.ObjectGraphType<MotivoMembroVagaReadModel>
    {
        public MotivoMembroVagaListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id,false);
            Field(x => x.Descricao,false);
            Field(x => x.Ativo,false);
        }
    }
}