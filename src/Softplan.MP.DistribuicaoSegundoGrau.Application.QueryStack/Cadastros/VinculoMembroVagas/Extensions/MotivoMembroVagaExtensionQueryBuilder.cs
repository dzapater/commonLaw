using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions
{
    public static class MotivoMembroVagaExtensionQueryBuilder
    {
        public static Specification<MotivoMembroVagaReadModel> FiltrarPorId(
            this Specification<MotivoMembroVagaReadModel> predicate, MotivoMembroVagaFilter filter)
            => filter.Id == null
                ? predicate
                : predicate.And(new IdMotivoMembroVagaReadModelEqualsSpecification(filter.Id));
        
        public static Specification<MotivoMembroVagaReadModel> FiltrarPorDescricao(
            this Specification<MotivoMembroVagaReadModel> predicate, MotivoMembroVagaFilter filter)
            => string.IsNullOrEmpty(filter.Busca)
                ? predicate
                : predicate.And(new DescricaoMotivoMembroVagaReadModelContainsSpecification(filter.Busca));
        
        public static Specification<MotivoMembroVagaReadModel> FiltrarPorAtivos(
            this Specification<MotivoMembroVagaReadModel> predicate, MotivoMembroVagaFilter filter)
            => string.IsNullOrEmpty(filter.Ativo)
                ? predicate
                : predicate.And(new AtivoMotivoMembroVagaReadModelEqualsSpecification(filter.Ativo));
        
        public static IQueryable<MotivoMembroVagaReadModel> ApplyListFilters(this IQueryable<MotivoMembroVagaReadModel> queryable,
            MotivoMembroVagaFilter filter)
            => queryable.Where(
                Specification<MotivoMembroVagaReadModel>.All
                    .FiltrarPorAtivos(filter)
                    .FiltrarPorId(filter)
                    .FiltrarPorDescricao(filter).ToExpression());
    }
}