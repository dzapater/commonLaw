using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IsVinculoMembroVagaAtivoSpecification : Specification<VinculoMembroVaga>
    {
        private readonly bool _somentAtivo;

        public IsVinculoMembroVagaAtivoSpecification(bool somentAtivo)
        {
            _somentAtivo = somentAtivo;
        }

        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.DataFinal >= DateTimeOffset.Now || x.DataFinal == null;
    }
}