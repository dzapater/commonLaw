using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications
{
    public class EscopoEquilibrioVinculoVagaRegraEqualsSpecification : Specification<VinculoVagaRegraDistribuicao>
    {
        private readonly EscopoEquilibrio? _escopo;

        public EscopoEquilibrioVinculoVagaRegraEqualsSpecification(EscopoEquilibrio? escopo)
        {
            _escopo = escopo;
        }

        public override Expression<Func<VinculoVagaRegraDistribuicao, bool>> ToExpression()
            => x => x.RegraDistribuicao.EscopoEquilibrio.Equals(_escopo);
    }
}