using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications
{
    public class IdVagaVinculoVagaRegraEqualsSpecification : Specification<VinculoVagaRegraDistribuicao>
    {
        private readonly int _idVaga;

        public IdVagaVinculoVagaRegraEqualsSpecification(int idVaga)
        {
            _idVaga = idVaga;
        }

        public override Expression<Func<VinculoVagaRegraDistribuicao, bool>> ToExpression()
            => x => x.Vaga.Id == _idVaga;
    }
}