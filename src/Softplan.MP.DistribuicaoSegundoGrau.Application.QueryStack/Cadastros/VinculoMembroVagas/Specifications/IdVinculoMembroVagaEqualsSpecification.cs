using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IdVinculoMembroVagaEqualsSpecification : Specification<VinculoMembroVaga>
    {
        private readonly int _idVinculoMembroVaga;

        public IdVinculoMembroVagaEqualsSpecification(int idVinculoMembroVaga)
        {
            _idVinculoMembroVaga = idVinculoMembroVaga;
        }
        
        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.Id == _idVinculoMembroVaga;
    }
}