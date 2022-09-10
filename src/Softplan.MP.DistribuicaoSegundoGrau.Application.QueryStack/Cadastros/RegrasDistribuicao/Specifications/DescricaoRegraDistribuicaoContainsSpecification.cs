using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class DescricaoRegraDistribuicaoContainsSpecification : Specification<RegraDistribuicao>
    {
        private readonly string _descricao;

        public DescricaoRegraDistribuicaoContainsSpecification(string descricao)
        {
            _descricao = descricao;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => x => x.Descricao.Trim().ToLower().Contains(_descricao.Trim().ToLower());
    }
}