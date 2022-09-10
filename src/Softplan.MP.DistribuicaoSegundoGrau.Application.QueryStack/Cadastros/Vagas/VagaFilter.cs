using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    public class VagaFilter : IPagedParams
    {
        public int Id { get; set; }
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string Busca { get; set; }
        public int IdOrgao { get; set; }
        public Area? IdArea { get; set; }
        public Situacao? Situacao{ get; set; }
        public string IdProcuradorTitular { get; set; }
        public string IdMembroAtividade { get; set; }
        public bool? PermiteReuPreso { get; set; }
        public bool? PermiteDistribuicao { get; set; }
        public bool? ConsiderarConfiguracoes { get; set; }
        public bool Ativos { get; set; }
        public bool Vinculadas { get; set; }
        public EscopoEquilibrio? EscopoEquilibrio { get; set; }
        public bool EscopoEquilibrioLocalOuIndefinido { get; set; }
        public int CdLocal { get; set; }
    }
}