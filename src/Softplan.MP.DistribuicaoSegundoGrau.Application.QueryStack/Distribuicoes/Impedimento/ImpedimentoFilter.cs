using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento
{
    public class ImpedimentoFilter : IPagedParams
    {
         public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string IdProcesso { get; set; }
        public int IdVaga { get; set; }
    }
}