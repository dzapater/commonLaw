using Softplan.Common.Core.Entities.Pages.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoFilter : IPagedParams
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Busca { get; set; }
        public int IdVaga { get; set; }
        public int IdRegraDistribuicao { get; set; }
    }
}