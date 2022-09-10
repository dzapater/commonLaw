using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class AreaRegraDistribuicaoPorBuscaEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly Area? _area;

        public AreaRegraDistribuicaoPorBuscaEqualsSpecification(Area? area)
        {
            _area = area;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Area.Equals(_area);
    }
}