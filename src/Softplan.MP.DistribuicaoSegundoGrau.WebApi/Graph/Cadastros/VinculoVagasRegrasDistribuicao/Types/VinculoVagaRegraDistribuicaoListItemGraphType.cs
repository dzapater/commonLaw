using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class VinculoVagaRegraDistribuicaoListItemGraphType : Softplan.Common.Graph.Types.ObjectGraphType<VinculoVagaRegraDistribuicaoReadModel>
    {
        public VinculoVagaRegraDistribuicaoListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.RegraDistribuicao, true, typeof(RegraDistribuicaoListItemGraphType));
            Field(x => x.Vaga, true, typeof(VagaListItemGraphType));
        }
    }
}