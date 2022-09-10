using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    public interface IHistoricoCompensacaoRegraQueryService: IQueryService
    {
        Task<ICustomPagedList<HistoricoCompensacaoRegraReadModel>> ListAsync(HistoricoCompensacaoRegraFilter filter,
            ICollection<Sort> sorts);
    }
}