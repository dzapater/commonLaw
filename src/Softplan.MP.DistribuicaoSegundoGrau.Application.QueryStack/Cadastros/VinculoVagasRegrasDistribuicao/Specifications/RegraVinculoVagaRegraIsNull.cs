using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications
{
    public class RegraVinculoVagaRegraIsNull : Specification<VinculoVagaRegraDistribuicao>
    {
        public override Expression<Func<VinculoVagaRegraDistribuicao, bool>> ToExpression()
            => x => x.RegraDistribuicao == null;
    }
}