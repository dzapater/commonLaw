using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class IdProcuradorTitularVagaEqualSpecification : Specification<Vaga>
    {
        private readonly string _idProcurador;

        public IdProcuradorTitularVagaEqualSpecification(string idProcurador)
        {
            _idProcurador = idProcurador;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.ProcuradorTitular.Id.ToLower().Equals(_idProcurador.ToLower());
    }
}