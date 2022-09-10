using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Specifications
{
    public class IdVagaProcessoReadModelEqualsSpecification : Specification<ImpedimentoProcesso>
    {
        private readonly int _idVaga;

        public IdVagaProcessoReadModelEqualsSpecification(int idVaga)
        {
            _idVaga = idVaga;
        }

        public override Expression<Func<ImpedimentoProcesso, bool>> ToExpression()
            => x => x.IdVaga == _idVaga;
    }
}