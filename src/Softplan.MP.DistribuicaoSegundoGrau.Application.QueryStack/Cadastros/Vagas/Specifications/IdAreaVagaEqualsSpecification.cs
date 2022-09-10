using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class IdAreaVagaEqualsSpecification : Specification<Vaga>
    {
        private readonly Area? _area;

        public IdAreaVagaEqualsSpecification(Area? area)
        {
            _area = area;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => _area switch
            {
                Area.Ambas => x => x.Area.Equals(Area.Ambas) || x.Area.Equals(Area.Civel) || x.Area.Equals(Area.Criminal),
                _ => x => x.Area.Equals(_area) || x.Area.Equals(Area.Ambas)
            };
    }
}