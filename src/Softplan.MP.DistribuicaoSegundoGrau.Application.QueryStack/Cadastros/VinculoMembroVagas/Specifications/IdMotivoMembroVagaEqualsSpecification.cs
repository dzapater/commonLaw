using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IdMotivoMembroVagaEqualsSpecification : Specification<VinculoMembroVaga>
    {
        private readonly int _idMotivoMembroVaga;

        public IdMotivoMembroVagaEqualsSpecification(int idMotivoMembroVaga)
        {
            _idMotivoMembroVaga = idMotivoMembroVaga;
        }
        
        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.IdMotivoMembroVaga == _idMotivoMembroVaga;
    }
}