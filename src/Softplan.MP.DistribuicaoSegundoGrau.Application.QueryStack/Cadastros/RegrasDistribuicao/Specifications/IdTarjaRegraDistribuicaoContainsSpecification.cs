using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{ 
    public class IdTarjaRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idTarja;

        public IdTarjaRegraDistribuicaoContainsSpecification(long idTarja)
        {
            _idTarja = idTarja;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Tarjas.Any(p => p.IdTarja == _idTarja);
    }
}