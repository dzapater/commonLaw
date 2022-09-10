namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaFilter 
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Busca { get; set; }
        public int Id { get; set; }
        public int IdVaga { get; set; }
        public string IdMembro { get; set; }
        public int IdMotivoMembroVaga { get; set; }
        public bool SomenteAtivo { get; set; }
    }
}