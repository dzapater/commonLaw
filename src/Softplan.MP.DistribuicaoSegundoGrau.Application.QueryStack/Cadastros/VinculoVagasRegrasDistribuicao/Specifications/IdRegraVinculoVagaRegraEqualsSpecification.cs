using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications
{
    public class IdRegraVinculoVagaRegraEqualsSpecification : Specification<VinculoVagaRegraDistribuicao>
    {
        private readonly int _idRegra;

        public IdRegraVinculoVagaRegraEqualsSpecification(int idRegra)
        {
            _idRegra = idRegra;
        }

        public override Expression<Func<VinculoVagaRegraDistribuicao, bool>> ToExpression()
            => x => x.RegraDistribuicao.Id == _idRegra;
    }
}