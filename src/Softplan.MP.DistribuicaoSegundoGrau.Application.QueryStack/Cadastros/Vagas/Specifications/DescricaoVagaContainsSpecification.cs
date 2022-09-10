using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class DescricaoVagaContainsSpecification : Specification<Vaga>
    {
        private readonly string _descricao;

        public DescricaoVagaContainsSpecification(string descricao)
        {
            _descricao = descricao;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.Descricao.ToLower().Contains(_descricao.ToLower());
    }
}