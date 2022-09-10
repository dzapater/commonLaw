using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class BuscaAreaVagaEqualsSpecification : Specification<Vaga>
    {
        private readonly Area? _area;

        public BuscaAreaVagaEqualsSpecification(Area? area)
        {
            _area = area;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.Area.Equals(_area);
    }
}