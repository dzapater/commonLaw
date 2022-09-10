using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class EscopoEquilibrioRegraDistribuicaoEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly EscopoEquilibrio? _escopoEquilibrio;

        public EscopoEquilibrioRegraDistribuicaoEqualsSpecification(EscopoEquilibrio? escopoEquilibrio)
        {
            _escopoEquilibrio = escopoEquilibrio;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.EscopoEquilibrio.Equals(_escopoEquilibrio);
    }
}