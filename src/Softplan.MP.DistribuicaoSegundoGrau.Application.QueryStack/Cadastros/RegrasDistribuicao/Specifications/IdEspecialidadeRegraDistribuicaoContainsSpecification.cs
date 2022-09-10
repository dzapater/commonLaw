using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdEspecialidadeRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly long _idEspecialidade;

        public IdEspecialidadeRegraDistribuicaoContainsSpecification(long idEspecialidade)
        {
            _idEspecialidade = idEspecialidade;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Especialidades.Any(p => p.IdEspecialidade == _idEspecialidade);
    }
}