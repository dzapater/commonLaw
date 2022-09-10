using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdUnidadeRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idUnidade;

        public IdUnidadeRegraDistribuicaoContainsSpecification(long idUnidade)
        {
            _idUnidade = idUnidade;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Unidades.Any(p => p.IdUnidade == _idUnidade);
    }
}