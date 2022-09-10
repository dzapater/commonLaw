using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public abstract class VagaInputType : Softplan.Common.Graph.Types.InputObjectGraphType<Domain.Cadastros.Vagas.Vaga>
    {
        protected VagaInputType()
        {
            Field(x => x.Descricao);
            Field(x => x.Orgao, type: typeof(OrgaoInputType));
            Field(x => x.ProcuradorTitular, type: typeof(ProcuradorInputType));
            Field(x => x.IdInstalacao);
            Field(x => x.ConsiderarConfiguracoesPrevencao,true);
            Field(x => x.PermiteReuPreso,true);
            Field(x => x.EstaAtiva,true);
            Field(x => x.PermiteDistribuicaoMesmaVaga,true);
            Field(x => x.Compensacao,true);
            Field(x => x.Distribuicoes, true);
            Field(x => x.Motivo,true);
            Field(x => x.Area, type: typeof(AreaGraphType));
        }
    }
}