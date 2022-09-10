using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdOrigemRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly int _idOrigem;

        public IdOrigemRegraDistribuicaoContainsSpecification(int idOrigem)
        {
            _idOrigem = idOrigem;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.OrgaosJulgadores.Any(p => p.IdOrigem == _idOrigem);
    }
}