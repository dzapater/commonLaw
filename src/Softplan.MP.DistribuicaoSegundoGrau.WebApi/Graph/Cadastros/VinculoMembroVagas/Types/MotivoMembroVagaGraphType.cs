using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class MotivoMembroVagaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<MotivoMembroVagaReadModel>
    {
        public MotivoMembroVagaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.Descricao, true);
            Field(x => x.Ativo, true);
        }
    }
}