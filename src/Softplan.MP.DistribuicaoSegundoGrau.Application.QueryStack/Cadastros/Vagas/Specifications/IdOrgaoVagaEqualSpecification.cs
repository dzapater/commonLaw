using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class IdOrgaoVagaEqualSpecification : Specification<Vaga>
    {
        private readonly int _idOrgao;

        public IdOrgaoVagaEqualSpecification(int idOrgao)
        {
            _idOrgao = idOrgao;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.Orgao.Id == _idOrgao;
    }
}