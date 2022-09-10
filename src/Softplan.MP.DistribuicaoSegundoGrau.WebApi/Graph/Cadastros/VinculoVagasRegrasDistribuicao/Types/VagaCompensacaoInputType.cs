namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class VagaCompensacaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<Domain.Cadastros.Vagas.Vaga>
    {
        public VagaCompensacaoInputType()
        {
            Field(x => x.Id);
            Field(x => x.Compensacao);
        }
    }
}
