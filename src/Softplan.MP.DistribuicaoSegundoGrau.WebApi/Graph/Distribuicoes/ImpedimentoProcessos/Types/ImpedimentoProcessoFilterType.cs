using Softplan.Common.Core.Entities.Pages.Abstractions;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos.Types
{
    public class ImpedimentoProcessoFilterType : Softplan.Common.Graph.Types.InputObjectGraphType<ImpedimentoFilter>
    {
        public ImpedimentoProcessoFilterType(IDescriptionProvider provider) : base(provider)
        {
            Field(x => x.IdProcesso, true);
            Field(x => x.IdVaga, true);
            Field(x => x.PageNumber, true);
            Field(x => x.PageSize, true);
        }
    }
    public class ImpedimentoProcessoFilter : IPagedParams
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string IdProcesso { get; set; }
        public int IdVaga { get; set; }
    }
}