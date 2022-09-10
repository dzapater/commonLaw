using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdOrgaoJulgadorRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idOrgao;

        public IdOrgaoJulgadorRegraDistribuicaoContainsSpecification(long idOrgao)
        {
            _idOrgao = idOrgao;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.OrgaosJulgadores.Any(p => p.IdOrgaoJulgador == _idOrgao);
    }
}