using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class AtivoRegraDistribuicaoEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly bool _ativo;

        public AtivoRegraDistribuicaoEqualsSpecification(bool ativo)
        {
            _ativo = ativo;
        }
        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Ativo.Equals(_ativo);
    }
}