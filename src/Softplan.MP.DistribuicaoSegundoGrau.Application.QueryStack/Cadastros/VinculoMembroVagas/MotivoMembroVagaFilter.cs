namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class MotivoMembroVagaFilter 
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Busca { get; set; }
        public int? Id { get; set; }
        public string Ativo { get; set; }
    }
}