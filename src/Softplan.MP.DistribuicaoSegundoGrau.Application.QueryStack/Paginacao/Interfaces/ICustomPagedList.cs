using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces
{
    public interface ICustomPagedList<T> : IList<T>, ICustomPagedInfo
    {
    }
}