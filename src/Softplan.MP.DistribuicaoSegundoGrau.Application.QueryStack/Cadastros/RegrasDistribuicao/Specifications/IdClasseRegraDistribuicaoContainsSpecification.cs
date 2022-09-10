using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdClasseRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idClasse;

        public IdClasseRegraDistribuicaoContainsSpecification(long idClasse)
        {
            _idClasse = idClasse;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Classes.Any(p => p.IdClasse == _idClasse);
    }
}