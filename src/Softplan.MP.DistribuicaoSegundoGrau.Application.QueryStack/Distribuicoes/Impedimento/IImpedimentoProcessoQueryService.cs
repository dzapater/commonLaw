using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento
{
    public interface IImpedimentoProcessoQueryService : IQueryService
    {
        Task<ICustomPagedList<ImpedimentoProcesso>> ListAsync(ImpedimentoFilter filter, ICollection<Sort> sorts);
    }
}