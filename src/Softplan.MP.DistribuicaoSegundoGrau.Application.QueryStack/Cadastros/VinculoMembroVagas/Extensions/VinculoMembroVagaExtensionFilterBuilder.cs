using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Extensions
{
    public static class VinculoMembroVagaExtensionFilterBuilder
    {
        public static Specification<VinculoMembroVaga> FiltrarPorId(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => filter.Id == default
                ? predicate
                : predicate.And(new IdVinculoMembroVagaEqualsSpecification(filter.Id));

        public static Specification<VinculoMembroVaga> FiltrarPorIdMembro(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => filter.IdMembro == default
                ? predicate
                : predicate.And(new IdMembroEqualsSpecification(filter.IdMembro));
        
        public static Specification<VinculoMembroVaga> FiltrarPorIdVaga(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => filter.IdVaga == default
                ? predicate
                : predicate.And(new IdVagaEqualsSpecification(filter.IdVaga));
        
        public static Specification<VinculoMembroVaga> FiltrarPorIdMotivoMembroVaga(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => filter.IdMotivoMembroVaga == default
                ? predicate
                : predicate.And(new IdMotivoMembroVagaEqualsSpecification(filter.IdMotivoMembroVaga));
        
        public static Specification<VinculoMembroVaga> FiltrarPorMembroAtivo(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => !filter.SomenteAtivo
                ? predicate
                : predicate.And(new IsVinculoMembroVagaAtivoSpecification(filter.SomenteAtivo));
        
        public static Specification<VinculoMembroVaga> FiltrarPorDescricaoVaga(
            this Specification<VinculoMembroVaga> predicate, VinculoMembroVagaFilter filter)
            => string.IsNullOrEmpty(filter.Busca)
                ? predicate
                : predicate.And(new DescricaoVagaContainsSpecification(filter.Busca));
    }
}