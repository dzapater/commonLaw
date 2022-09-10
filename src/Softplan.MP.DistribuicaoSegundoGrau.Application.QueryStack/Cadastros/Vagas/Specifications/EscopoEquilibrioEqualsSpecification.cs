using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class EscopoEquilibrioEqualsSpecification : Specification<Vaga>
    {
        private readonly EscopoEquilibrio? _escopoEquilibrio;

        public EscopoEquilibrioEqualsSpecification(EscopoEquilibrio? escopoEquilibrio)
        {
            _escopoEquilibrio = escopoEquilibrio;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.RegrasVinculadas
                        .Any(v => v.RegraDistribuicao.EscopoEquilibrio.Equals(_escopoEquilibrio))
                    || !x.RegrasVinculadas.Any();
    }
}