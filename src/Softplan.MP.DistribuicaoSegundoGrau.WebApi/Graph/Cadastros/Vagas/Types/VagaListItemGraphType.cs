using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class VagaListItemGraphType : Softplan.Common.Graph.Types.ObjectGraphType<VagaReadModel>
    {
        public VagaListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            FieldsDadosGerais();
            FieldsDistribuicoes();
            FieldsMembroEmAtividade();
        }

        private void FieldsDadosGerais()
        {
            Field(x => x.Id);
            Field(x => x.Descricao);
            Field(x => x.EstaAtiva);
            Field(x => x.Orgao, true, type:typeof(OrgaoGraphType));   
            Field(x => x.IdInstalacao);
            Field(x => x.ConsiderarConfiguracoesPrevencao);
            Field(x => x.PermiteReuPreso);
            Field(x => x.PermiteDistribuicaoMesmaVaga);
            Field(x => x.DataAtualizacao);
            Field(x => x.ExisteVagaPendente);
            Field(x => x.Area, type: typeof(AreaGraphType));
            Field(x => x.ProcuradorTitular, true, type: typeof(ProcuradorTitularGraphType));
            Field(x => x.Instalacao, type: typeof(ForoGraphType));
            Field(x => x.Situacao, type: typeof(SituacaoGraphType));
            Field(x => x.CdLocal);
            Field(x => x.PossuiVinculoRegraGlobal);
            Field(x => x.IdVinculoRegraGlobal, true);
        }

        private void FieldsDistribuicoes()
        {
            Field(x => x.Distribuicoes); 
            Field(x => x.Compensacao);
            Field(x => x.DistribuicaoPorVolume);
            Field(x => x.CompensacaoPorVolume);
        }

        private void FieldsMembroEmAtividade()
        {
            Field(x => x.MembroEmAtividade, true, typeof(ProcuradorTitularGraphType));
            Field(x => x.DataInicial, true);
            Field(x => x.DataFinal, true);
        }
    }
}