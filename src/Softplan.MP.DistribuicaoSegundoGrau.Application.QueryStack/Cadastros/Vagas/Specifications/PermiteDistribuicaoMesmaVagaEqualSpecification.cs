using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class PermiteDistribuicaoMesmaVagaEqualSpecification : Specification<Vaga>
    {
        private readonly bool? _permiteDistribuicaoMesmaVaga;

        public PermiteDistribuicaoMesmaVagaEqualSpecification(bool? permiteDistribuicaoMesmaVaga)
        {
            _permiteDistribuicaoMesmaVaga = permiteDistribuicaoMesmaVaga;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.PermiteDistribuicaoMesmaVaga == _permiteDistribuicaoMesmaVaga;
    }
}