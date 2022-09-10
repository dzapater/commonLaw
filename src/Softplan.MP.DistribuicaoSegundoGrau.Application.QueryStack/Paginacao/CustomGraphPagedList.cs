using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Implementations;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao
{
    public class CustomGraphPagedList<T> : CustomPagedList<T>
    {
        public CustomGraphPagedList()
        {
        }
        
        public CustomGraphPagedList(ICustomPagedList<T> pagedList)
        {
            if (pagedList == null)
                return;
            PageInfo = pagedList.PageInfo;
            AddRange(pagedList);
        }

        public ICollection<T> Items
        {
            get => this.ToList();
            set
            {
                Clear();
                if (value == null)
                    return;
                AddRange(value);
            }
        }
    }
}