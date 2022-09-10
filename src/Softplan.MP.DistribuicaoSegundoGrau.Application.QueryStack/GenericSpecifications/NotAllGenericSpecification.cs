using System;
using System.Linq.Expressions;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications
{
    public class NotAllGenericSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression() => x => false;
    }
}