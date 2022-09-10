using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class PermiteReuPresoVagaEqualSpecification : Specification<Vaga>
    {
        private readonly bool? _permiteReuPreso;

        public PermiteReuPresoVagaEqualSpecification(bool? permiteReuPreso)
        {
            _permiteReuPreso = permiteReuPreso;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.PermiteReuPreso == _permiteReuPreso;
    }
}