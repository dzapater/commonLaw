using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class EscopoLocalOuIndefinidoSpecification : Specification<Vaga>
    {
        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => !x.RegrasVinculadas
                .Select(r => r.RegraDistribuicao)
                .Any(e => e.EscopoEquilibrio.Equals(EscopoEquilibrio.Global));
    }
}