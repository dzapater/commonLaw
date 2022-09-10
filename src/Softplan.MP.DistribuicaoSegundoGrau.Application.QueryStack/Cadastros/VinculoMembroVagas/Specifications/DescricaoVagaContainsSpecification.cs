using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class DescricaoVagaContainsSpecification : Specification<VinculoMembroVaga>
    {
        private readonly string _descricaoVaga;

        public DescricaoVagaContainsSpecification(string descricaoVaga)
        {
            _descricaoVaga = descricaoVaga;
        }

        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.Vaga.Descricao.ToLower().Contains(_descricaoVaga.ToLower());
    }
}