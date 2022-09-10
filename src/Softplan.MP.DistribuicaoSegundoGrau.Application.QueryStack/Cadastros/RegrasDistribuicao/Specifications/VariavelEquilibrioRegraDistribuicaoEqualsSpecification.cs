using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class VariavelEquilibrioRegraDistribuicaoEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly VariavelEquilibrio? _variavelEquilibrio;

        public VariavelEquilibrioRegraDistribuicaoEqualsSpecification(VariavelEquilibrio? variavelEquilibrio)
        {
            _variavelEquilibrio = variavelEquilibrio;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.VariavelEquilibrio.Equals(_variavelEquilibrio);
    }
}