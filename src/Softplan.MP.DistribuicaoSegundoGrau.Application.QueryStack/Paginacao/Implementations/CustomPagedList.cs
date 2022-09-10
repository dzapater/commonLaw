using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Implementations
{
    public class CustomPagedList<T> : List<T>, ICustomPagedList<T>
    {
        public CustomPagedList() => PageInfo = new CustomPageInfo();

        public CustomPagedList(IEnumerable<T> items, int currentPage, int pageSize, bool hasNext, int totalRecords)
        {
            PageInfo = new CustomPageInfo
            {
                HasNext = hasNext,
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalRecords = totalRecords
            };
            AddRange(items);
        }
        
        public ICustomPageInfo PageInfo { get; set; }
    }
}