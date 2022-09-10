using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types
{
    public class VinculoMembroVagaListItemGraphType: Softplan.Common.Graph.Types.ObjectGraphType<VinculoMembroVagaReadModel>
    {
        public VinculoMembroVagaListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id,true);
            Field(x => x.IdVaga,false);
            Field(x => x.IdMembro,true);
            Field(x => x.IdMotivoMembroVaga,false);
            Field(x => x.Observacao,true);
            Field(x => x.DataInicial,true);
            Field(x => x.DataFinal,true);
            Field(x => x.Vaga, true, typeof(VagaListItemGraphType));
            Field(x => x.Membro,true, type: typeof(ProcuradorTitularGraphType));
            Field(x => x.Motivo, true, typeof(MotivoMembroVagaGraphType));
        }
    }
}