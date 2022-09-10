using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class HistoricoCompensacaoRegraListGraphType : Softplan.Common.Graph.Types.ObjectGraphType<HistoricoCompensacaoRegraReadModel>
    {
        public HistoricoCompensacaoRegraListGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Descricao);
            Field(x => x.Motivo);
            Field(x => x.Usuario, true);
            Field(x => x.Compensado);
            Field(x => x.DataRegistro);
        }
    }
}