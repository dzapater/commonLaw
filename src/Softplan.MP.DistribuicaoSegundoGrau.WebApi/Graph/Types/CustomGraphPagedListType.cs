using GraphQL.Types;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class CustomGraphPagedListType<TGraph, TModel> : Common.Graph.Types.ObjectGraphType<CustomGraphPagedList<TModel>>
        where TGraph : IGraphType
    {
        public CustomGraphPagedListType(IDescriptionProvider descriptionProvider)
            : base(descriptionProvider)
        {
            Name = typeof (TGraph).Name + "List";
            MapFields();
        }

        private void MapFields()
        {
            Field(x => x.PageInfo, false, typeof (CustomPageInfoType));
            Field(x => x.Items, false, typeof (ListGraphType<TGraph>));
        }
    }
}