using System;
using System.Linq.Expressions;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IdMotivoMembroVagaReadModelEqualsSpecification : Specification<MotivoMembroVagaReadModel>
    {
        private readonly int? _idMotivoMembroVaga;

        public IdMotivoMembroVagaReadModelEqualsSpecification(int? idMotivoMembroVaga)
        {
            _idMotivoMembroVaga = idMotivoMembroVaga;
        }
        
        public override Expression<Func<MotivoMembroVagaReadModel, bool>> ToExpression()
            => x => x.Id == _idMotivoMembroVaga;
    }
}