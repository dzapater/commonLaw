using Softplan.Common.Core.Entities.Pages.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class HistoricoCompensacaoRegraFilter : IPagedParams
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int IdRegraDistribuicao { get; set; }
    }
}