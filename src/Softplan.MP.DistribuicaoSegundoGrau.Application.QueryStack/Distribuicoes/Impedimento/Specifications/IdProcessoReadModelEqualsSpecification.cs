
using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Specifications
{
    public class IdProcessoReadModelEqualsSpecification : Specification<ImpedimentoProcesso>
    {
        private readonly string _idProcesso;

        public IdProcessoReadModelEqualsSpecification(string idProcesso)
        {
            _idProcesso = idProcesso;
        }

        public override Expression<Func<ImpedimentoProcesso, bool>> ToExpression()
            => x => x.IdProcesso.ToLower().Equals(_idProcesso.ToLower());
    }
}