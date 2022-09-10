using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Graph.Types;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Implementations;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class CustomPageInfoType : ObjectGraphType<CustomPageInfo>
    {
        public CustomPageInfoType(IDescriptionProvider descriptionProvider)
            : base(descriptionProvider)
        {
            Field(x => x.CurrentPage);
            Field(x => x.PageSize);
            Field(x => x.HasPrevious);
            Field(x => x.HasNext);
            Field(x => x.TotalRecords);
            Field(x => x.TotalPages);
        }
    }
}