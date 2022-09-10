namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types
{
    public class VagaCompensacaoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<Domain.Cadastros.VinculoVagasRegrasDistribuicao.VagaCompensacao>
    {
        public VagaCompensacaoGraphType()
        {
            Field(x => x.IdVaga);
            Field(x => x.Motivo);
            Field(X => X.IdRegraDistribuicao);
            Field(x => x.Compensacao);
        }
    }
}
