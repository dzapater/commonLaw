using Softplan.Common.Core.Entities.Pages.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaFilter : IPagedParams
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public int IdVaga { get; set; }
        public int? IdClasse { get; set; }
        public int? IdAssunto { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdOrigem { get; set; }
        public int? IdUnidade { get; set; }
        public int? IdOrgaoJulgador { get; set; }
        public long? IdTarja { get; set; }
        
    }
}