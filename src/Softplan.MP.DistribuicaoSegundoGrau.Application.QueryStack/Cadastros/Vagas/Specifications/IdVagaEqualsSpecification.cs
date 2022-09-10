using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class IdVagaEqualsSpecification : Specification<Vaga>
    {
        private readonly int _idVaga;

        public IdVagaEqualsSpecification(int idVaga)
        {
            _idVaga = idVaga;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.Id == _idVaga;
    }
}