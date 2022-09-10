using System;
using System.Linq.Expressions;
using Softplan.Common.Core.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Extensions
{
    public static class VagaExtensionFilterBuilder
    {
        private static Specification<Vaga> FiltrarVagasVinculadasARegras(this Specification<Vaga> specification,
            VagaFilter filter)
            => filter.Vinculadas
                ? specification.And(new PossuiRegraVinculadaSpecification())
                : specification;

        private static Specification<Vaga> FiltrarPorIdVaga(
            this Specification<Vaga> specification, VagaFilter filter)
            => filter.Id == default
                ? specification
                : specification.And(new IdVagaEqualsSpecification(filter.Id));
        
        private static Specification<Vaga> FiltrarPorVagasAtivas(
            this Specification<Vaga> specification, VagaFilter filter)
            => filter.Ativos
                ? specification.And(new EstaAtivoVagaEqualSpecification(filter.Ativos))
                : specification;

        private static Specification<Vaga> FiltrarDescricaoPorBusca(
            this Specification<Vaga> specification, VagaFilter filter)
            => specification.Or(new DescricaoVagaContainsSpecification(filter.Busca));       

        private static Specification<Vaga> FiltrarAreaPorBusca(
            this Specification<Vaga> specification, VagaFilter filter)
            => Enum.TryParse<Area>(filter.Busca, true, out var area)
                ? specification.Or(new BuscaAreaVagaEqualsSpecification(area))
                : specification;

        private static Specification<Vaga> FiltrarPorIdOrgao(
           this Specification<Vaga> specification, VagaFilter filter)
           => filter.IdOrgao == default
                ? specification
                : specification.And(new IdOrgaoVagaEqualSpecification(filter.IdOrgao));
       
        private static Specification<Vaga> FiltrarPorArea(
           this Specification<Vaga> specification, VagaFilter filter)
           => filter.IdArea == null
               ? specification
               : specification.And(new IdAreaVagaEqualsSpecification(filter.IdArea));
        
        private static Specification<Vaga> FiltrarPorConfiguracoesPrevencao(
           this Specification<Vaga> specification, VagaFilter filter)
           => filter.ConsiderarConfiguracoes == null
                ? specification
                : specification.And(new ConsiderarConfiguracoesPrevencaoVagaEqualSpecification(filter.ConsiderarConfiguracoes));

        private static Specification<Vaga> FiltrarPermiteReuPreso(
           this Specification<Vaga> specification, VagaFilter filter)
           => filter.PermiteReuPreso == null
                ? specification
                : specification.And(new PermiteReuPresoVagaEqualSpecification(filter.PermiteReuPreso));

        private static Specification<Vaga> FiltrarPermiteDistribuicao(
           this Specification<Vaga> specification, VagaFilter filter)
           => filter.PermiteDistribuicao == null
                ? specification
                : specification.And(new PermiteDistribuicaoMesmaVagaEqualSpecification(filter.PermiteDistribuicao));

        private static Specification<Vaga> FiltrarPorIdProcuradorTitular(
           this Specification<Vaga> specification, VagaFilter filter)
           => string.IsNullOrWhiteSpace(filter.IdProcuradorTitular)
                ? specification
                : specification.And(new IdProcuradorTitularVagaEqualSpecification(filter.IdProcuradorTitular));
        
        private static Specification<Vaga> FiltrarPorEscopoEquilibrioRegra(
            this Specification<Vaga> specification, VagaFilter filter)
            => filter.EscopoEquilibrio.HasValue
                ? specification.And(new EscopoEquilibrioEqualsSpecification(filter.EscopoEquilibrio))
                : specification;

        private static Specification<Vaga> FiltrarPorEscopoLocalOuIndefinido(this Specification<Vaga> specification,
            VagaFilter filter)
            => filter.EscopoEquilibrioLocalOuIndefinido
                ? specification.And(new EscopoLocalOuIndefinidoSpecification())
                : specification;

        private static Expression<Func<Vaga, bool>> ApplyListAndFilters(VagaFilter filter)
            => Specification<Vaga>.All
                .FiltrarVagasVinculadasARegras(filter)
                .FiltrarPorVagasAtivas(filter)
                .FiltrarPorIdVaga(filter)
                .FiltrarPorIdOrgao(filter)
                .FiltrarPorConfiguracoesPrevencao(filter)
                .FiltrarPorIdProcuradorTitular(filter)
                .FiltrarPorArea(filter)
                .FiltrarPermiteReuPreso(filter)
                .FiltrarPermiteDistribuicao(filter)
                .FiltrarPorEscopoEquilibrioRegra(filter)
                .FiltrarPorEscopoLocalOuIndefinido(filter).ToExpression();
        
        private static Expression<Func<Vaga, bool>> ApplyListOrFilters(VagaFilter filter)
            => CustomSpecification<Vaga>.NotAll
                .FiltrarAreaPorBusca(filter)
                .FiltrarDescricaoPorBusca(filter).ToExpression();
        
        public static Expression<Func<Vaga, bool>> ApplyListFilters(VagaFilter filter)
        {
            var expression = ApplyListAndFilters(filter);
            return string.IsNullOrWhiteSpace(filter.Busca)
                ? expression
                : expression.AndAlso(ApplyListOrFilters(filter));
        }
    }
}