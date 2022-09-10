using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class IdMembroEqualsSpecification : Specification<VinculoMembroVaga>
    {
        private readonly string _idMembro;

        public IdMembroEqualsSpecification(string idMembro)
        {
            _idMembro = idMembro;
        }
        
        public override Expression<Func<VinculoMembroVaga, bool>> ToExpression()
            => x => x.IdMembro.Trim().ToLower().Equals(_idMembro.Trim().ToLower());
    }
}