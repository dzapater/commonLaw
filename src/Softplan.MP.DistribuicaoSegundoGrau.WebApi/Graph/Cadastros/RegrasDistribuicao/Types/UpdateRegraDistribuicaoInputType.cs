namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class UpdateRegraDistribuicaoInputType : RegraDistribuicaoInputType
    {
        public UpdateRegraDistribuicaoInputType()
        {
            Field(x => x.Id);
        }
    }
}