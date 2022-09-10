using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdAssuntoRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idAssunto;

        public IdAssuntoRegraDistribuicaoContainsSpecification(long idAssunto)
        {
            _idAssunto = idAssunto;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Assuntos.Any(p => p.IdAssunto == _idAssunto);
    }
}