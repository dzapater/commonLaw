using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Extensions
{
    public static class VinculoVagaRegraExtensionFilterBuilder
    {
        public static Specification<VinculoVagaRegraDistribuicao> FiltrarPorIdVaga(
            this Specification<VinculoVagaRegraDistribuicao> specification, VinculoVagaRegraDistribuicaoFilter filter)
            => filter.IdVaga == default
                ? specification
                : specification.And(new IdVagaVinculoVagaRegraEqualsSpecification(filter.IdVaga));
        
        public static Specification<VinculoVagaRegraDistribuicao> FiltrarPorIdRegraDistribuicao(
            this Specification<VinculoVagaRegraDistribuicao> specification, VinculoVagaRegraDistribuicaoFilter filter)
            => filter.IdRegraDistribuicao == default
                ? specification
                : specification.And(new IdRegraVinculoVagaRegraEqualsSpecification(filter.IdRegraDistribuicao));

        public static Specification<VinculoVagaRegraDistribuicao> FiltrarDescricaoVagaPorBusca(
            this Specification<VinculoVagaRegraDistribuicao> specification, VinculoVagaRegraDistribuicaoFilter filter)
            => specification.Or(new DescricaoVagaVinculoVagaRegraContainsSpecification(filter.Busca));
        
        public static Specification<VinculoVagaRegraDistribuicao> FiltrarDescricaoRegraPorBusca(
            this Specification<VinculoVagaRegraDistribuicao> specification, VinculoVagaRegraDistribuicaoFilter filter)
            => specification.Or(new DescricaoRegraVinculoVagaRegraContainsSpecification(filter.Busca));

        public static Specification<VinculoVagaRegraDistribuicao> FiltrarDescricaoPorBusca(
            this Specification<VinculoVagaRegraDistribuicao> specification, VinculoVagaRegraDistribuicaoFilter filter)
            => string.IsNullOrWhiteSpace(filter.Busca)
                ? specification
                : CustomSpecification<VinculoVagaRegraDistribuicao>.NotAll
                    .FiltrarDescricaoRegraPorBusca(filter)
                    .FiltrarDescricaoVagaPorBusca(filter);

        public static Expression<Func<VinculoVagaRegraDistribuicao, bool>> ApplyListFilter(VinculoVagaRegraDistribuicaoFilter filter)
            => Specification<VinculoVagaRegraDistribuicao>.All
                .FiltrarDescricaoPorBusca(filter)
                .FiltrarPorIdRegraDistribuicao(filter)
                .FiltrarPorIdVaga(filter).ToExpression();
    }
}