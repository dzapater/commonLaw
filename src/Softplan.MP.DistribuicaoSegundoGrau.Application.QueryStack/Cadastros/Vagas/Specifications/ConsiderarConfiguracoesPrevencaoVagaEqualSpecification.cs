using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class ConsiderarConfiguracoesPrevencaoVagaEqualSpecification : Specification<Vaga>
    {
        private readonly bool? _considerar;

        public ConsiderarConfiguracoesPrevencaoVagaEqualSpecification(bool? considerar)
        {
            _considerar = considerar;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.ConsiderarConfiguracoesPrevencao == _considerar;
    }
}