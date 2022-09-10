using System;
using System.Linq.Expressions;
using Softplan.Common.Core.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoExtensionFilterBuilder
    {
        public static Specification<RegraDistribuicao> FiltrarPorIdOrgaoJulgador(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdOrgao == default
                ? specification
                : specification.And(new IdOrgaoJulgadorRegraDistribuicaoContainsSpecification(filter.IdOrgao));
        
        public static Specification<RegraDistribuicao> FiltrarPorIdClasse(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdClasse == default
                ? specification
                : specification.And(new IdClasseRegraDistribuicaoContainsSpecification(filter.IdClasse));
        
        public static Specification<RegraDistribuicao> FiltrarPorIdEspecialidade(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdEspecialidade == default
                ? specification
                : specification.And(new IdEspecialidadeRegraDistribuicaoContainsSpecification(filter.IdEspecialidade));

        public static Specification<RegraDistribuicao> FiltrarPorIdAssunto(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdAssunto == default
                ? specification
                : specification.And(new IdAssuntoRegraDistribuicaoContainsSpecification(filter.IdAssunto));
        
        public static Specification<RegraDistribuicao> FiltrarPorIdTarja(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdTarja == default
                ? specification
                : specification.And(new IdTarjaRegraDistribuicaoContainsSpecification(filter.IdTarja));
        
        public static Specification<RegraDistribuicao> FiltrarPorIdUnidade(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdUnidade == default
                ? specification
                : specification.And(new IdUnidadeRegraDistribuicaoContainsSpecification(filter.IdUnidade));
        
        public static Specification<RegraDistribuicao> FiltrarPorIdOrigem(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.IdOrigem == default
                ? specification
                : specification.And(new IdOrigemRegraDistribuicaoContainsSpecification(filter.IdOrigem));
        
        public static Specification<RegraDistribuicao> FiltrarPorArea(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.Area == null
                ? specification
                : specification.And(new IdAreaRegraDistribuicaoEqualsSpecification(filter.Area));

        public static Specification<RegraDistribuicaoEspecialidadeReadModel> FiltrarPorSituacao(
           this Specification<RegraDistribuicaoEspecialidadeReadModel> specification, RegraDistribuicaoFilter filter)
           => filter.Situacao == null
               ? specification
               : specification.And(new SituacaoRegraDistribuicaoEspecialidadeEqualsSpecification(filter.Situacao));

        public static Specification<RegraDistribuicao> FiltrarPorEscopoEquilibrio(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.EscopoEquilibrio == null
                ? specification
                : specification.And(new EscopoEquilibrioRegraDistribuicaoEqualsSpecification(filter.EscopoEquilibrio));
        
        public static Specification<RegraDistribuicao> FiltrarPorVariavelEquilibrio(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.VariavelEquilibrio == null
                ? specification
                : specification.And(new VariavelEquilibrioRegraDistribuicaoEqualsSpecification(filter.VariavelEquilibrio));
        
        public static Specification<RegraDistribuicao> FiltrarPorTipoProcesso(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.TipoProcesso == null
                ? specification
                : specification.And(new TipoProcessoRegraDistribuicaoEqualsSpecification(filter.TipoProcesso));
        
        public static Specification<RegraDistribuicao> FiltrarAtivos(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.Ativos
                ? specification.And(new AtivoRegraDistribuicaoEqualsSpecification(filter.Ativos))
                : specification;
        
        public static Specification<RegraDistribuicao> FiltrarPorDescricao(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => filter.Descricao == null
                ? specification
                : specification.And(new DescricaoRegraDistribuicaoContainsSpecification(filter.Descricao));

        public static Specification<RegraDistribuicao> FiltrarDescricaoPorBusca(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => specification.Or(new DescricaoRegraDistribuicaoContainsSpecification(filter.Busca));
        
        public static Specification<RegraDistribuicao> FiltrarAreaPorBusca(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => Enum.TryParse<Area>(filter.Busca, true, out var area)
                ? specification.Or(new AreaRegraDistribuicaoPorBuscaEqualsSpecification(area))
                : specification;
        
        public static Specification<RegraDistribuicao> FiltrarEscopoEquilibrioPorBusca(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => Enum.TryParse<EscopoEquilibrio>(filter.Busca, true, out var escopoEquilibrio)
                ? specification.Or(new EscopoEquilibrioRegraDistribuicaoEqualsSpecification(escopoEquilibrio))
                : specification;
        
        public static Specification<RegraDistribuicao> FiltrarVariavelEquilibrioPorBusca(
            this Specification<RegraDistribuicao> specification, RegraDistribuicaoFilter filter)
            => Enum.TryParse<VariavelEquilibrio>(filter.Busca, true, out var variavelEquilibrio)
                ? specification.Or(new VariavelEquilibrioRegraDistribuicaoEqualsSpecification(variavelEquilibrio))
                : specification;
        
        private static Expression<Func<RegraDistribuicao, bool>> ApplyListAndFilters(RegraDistribuicaoFilter filter)
            => Specification<RegraDistribuicao>.All
                .FiltrarPorDescricao(filter)
                .FiltrarPorIdEspecialidade(filter)
                .FiltrarPorIdClasse(filter)
                .FiltrarPorIdOrgaoJulgador(filter)
                .FiltrarPorIdAssunto(filter)
                .FiltrarPorIdUnidade(filter)
                .FiltrarPorIdOrigem(filter)
                .FiltrarPorIdTarja(filter)
                .FiltrarPorArea(filter)
                .FiltrarPorEscopoEquilibrio(filter)
                .FiltrarPorVariavelEquilibrio(filter)
                .FiltrarPorTipoProcesso(filter)
                .FiltrarAtivos(filter).ToExpression();

        private static Expression<Func<RegraDistribuicao, bool>> ApplyListOrFilters(RegraDistribuicaoFilter filter)
            => CustomSpecification<RegraDistribuicao>.NotAll
                .FiltrarVariavelEquilibrioPorBusca(filter)
                .FiltrarEscopoEquilibrioPorBusca(filter)
                .FiltrarAreaPorBusca(filter)
                .FiltrarDescricaoPorBusca(filter).ToExpression();

        public static Expression<Func<RegraDistribuicao, bool>> ApplyListFilters(RegraDistribuicaoFilter filter)
        {
            var expression = ApplyListAndFilters(filter);
            return string.IsNullOrWhiteSpace(filter.Busca)
                ? expression
                : expression.AndAlso(ApplyListOrFilters(filter));
        }
        
        public static Expression<Func<RegraDistribuicaoEspecialidadeReadModel, bool>> ApplyFilterPorSituacao(RegraDistribuicaoFilter filter)
            => Specification<RegraDistribuicaoEspecialidadeReadModel>.All
                .FiltrarPorSituacao(filter).ToExpression();
    }
}