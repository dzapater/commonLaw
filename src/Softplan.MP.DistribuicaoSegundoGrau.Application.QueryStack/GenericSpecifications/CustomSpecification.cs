using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications
{
    public abstract class CustomSpecification<T> : Specification<T>
    {
        public static readonly Specification<T> NotAll = new NotAllGenericSpecification<T>();
    }
}