using System;
using System.Linq.Expressions;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class IdMembroAtividadeVagaReadModelEqualsSpecification : Specification<VagaReadModel>
    {
        private readonly string _idMembroAtividade;

        public IdMembroAtividadeVagaReadModelEqualsSpecification(string idMembroAtividade)
        {
            _idMembroAtividade = idMembroAtividade;
        }

        public override Expression<Func<VagaReadModel, bool>> ToExpression()
            => x => x.MembroEmAtividade.Id.ToLower().Equals(_idMembroAtividade.Trim().ToLower());
    }
}