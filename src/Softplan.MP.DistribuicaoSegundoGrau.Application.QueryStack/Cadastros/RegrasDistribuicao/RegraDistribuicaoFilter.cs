using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoFilter : IPagedParams
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Busca { get; set; }
        public bool Ativos { get; set; }
        public long IdEspecialidade { get; set; }
        public long IdClasse { get; set; }
        public long IdOrgao { get; set; }
        public long IdAssunto { get; set; }
        public long IdUnidade { get; set; }
        public long IdTarja { get; set; }
        public int IdOrigem { get; set; }
        public TipoProcesso? TipoProcesso { get; set; }
        public Area? Area { get; set; }
        public Situacao? Situacao { get; set; }
        public EscopoEquilibrio? EscopoEquilibrio { get; set; }
        public VariavelEquilibrio? VariavelEquilibrio { get; set; }
        public string Descricao { get; set; }
        public int CdLocal { get; set; }

        public static RegraDistribuicaoFilter Empty() => new RegraDistribuicaoFilter();
    }
}