using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class VagaGraphType : Softplan.Common.Graph.Types.ObjectGraphType<Domain.Cadastros.Vagas.Vaga>
    {
        public VagaGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.Descricao);
            Field(x => x.Orgao, type: typeof(OrgaoGraphType));
            Field(x => x.ProcuradorTitular, type:typeof(ProcuradorTitularGraphType));
            Field(x => x.IdInstalacao);
            Field(x => x.ConsiderarConfiguracoesPrevencao);
            Field(x => x.PermiteReuPreso);
            Field(x => x.EstaAtiva);
            Field(x => x.PermiteDistribuicaoMesmaVaga);
            Field(x => x.Distribuicoes);
            Field(x => x.Compensacao);
            Field(x => x.DistribuicaoPorVolume);
            Field(x => x.CompensacaoPorVolume);
            Field(x => x.Motivo);
            Field(x => x.Area, type: typeof(AreaGraphType));
            Field(x => x.Mensagens, true);
        }
    }
}
