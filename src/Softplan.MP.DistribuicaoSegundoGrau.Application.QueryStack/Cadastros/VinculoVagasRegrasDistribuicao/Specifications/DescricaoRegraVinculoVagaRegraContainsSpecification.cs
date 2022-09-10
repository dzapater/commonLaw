using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications
{
    public class DescricaoRegraVinculoVagaRegraContainsSpecification : Specification<VinculoVagaRegraDistribuicao>
    {
        private readonly string _descricao;

        public DescricaoRegraVinculoVagaRegraContainsSpecification(string descricao)
        {
            _descricao = descricao;
        }

        public override Expression<Func<VinculoVagaRegraDistribuicao, bool>> ToExpression()
            => x => x.RegraDistribuicao.Descricao.ToLower()
                .Contains(_descricao.ToLower());
    }
}