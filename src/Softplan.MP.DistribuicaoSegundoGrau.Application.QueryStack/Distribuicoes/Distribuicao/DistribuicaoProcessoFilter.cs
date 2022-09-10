namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao
{
    public class DistribuicaoProcessoFilter
    {
        public long Id { get; set; }
        public string IdProcesso { get; set; }
        
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
    }
}