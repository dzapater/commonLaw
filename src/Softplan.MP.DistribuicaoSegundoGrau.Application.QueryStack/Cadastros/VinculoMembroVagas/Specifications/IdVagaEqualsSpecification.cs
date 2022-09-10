using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IdVagaEqualsSpecification : Specification<VinculoMembroVaga>
    {
        private readonly int _idVaga;

        public IdVagaEqualsSpecification(int idVaga)
        {
            _idVaga = idVaga;
        }
        
        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.Vaga.Id == _idVaga;
    }
}