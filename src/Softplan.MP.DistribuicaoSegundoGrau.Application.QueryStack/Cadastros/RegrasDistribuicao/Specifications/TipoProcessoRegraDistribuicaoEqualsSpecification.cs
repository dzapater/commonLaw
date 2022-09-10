using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class TipoProcessoRegraDistribuicaoEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly TipoProcesso? _tipoProcesso;

        public TipoProcessoRegraDistribuicaoEqualsSpecification(TipoProcesso? tipoProcesso)
        {
            _tipoProcesso = tipoProcesso;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.TipoProcesso.Equals(_tipoProcesso);
    }
}