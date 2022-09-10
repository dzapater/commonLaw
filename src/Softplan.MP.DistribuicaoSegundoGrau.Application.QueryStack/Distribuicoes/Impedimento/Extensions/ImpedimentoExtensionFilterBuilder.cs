using System;
using System.Linq.Expressions;
using Softplan.Common.Core.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Specifications;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.GenericSpecifications;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento.Extensions
{
    public static class ImpedimentoExtensionFilterBuilder
    {
        private static Specification<ImpedimentoProcesso> FiltrarPorIdVaga(
            this Specification<ImpedimentoProcesso> specification, ImpedimentoFilter filter)
            => filter.IdVaga == default
                ? specification
                : specification.And(new IdVagaProcessoReadModelEqualsSpecification(filter.IdVaga));

        private static Specification<ImpedimentoProcesso> FiltrarPorIdProcesso(
           this Specification<ImpedimentoProcesso> specification, ImpedimentoFilter filter)
           => string.IsNullOrWhiteSpace(filter.IdProcesso) 
               ? specification
               : specification.And(new IdProcessoReadModelEqualsSpecification(filter.IdProcesso));
         

        private static Expression<Func<ImpedimentoProcesso, bool>> ApplyListAndFilters(ImpedimentoFilter filter)
            => Specification<ImpedimentoProcesso>.All               
                .FiltrarPorIdVaga(filter)
                .FiltrarPorIdProcesso(filter).ToExpression();        
        
        public static Expression<Func<ImpedimentoProcesso, bool>> ApplyListFilters(ImpedimentoFilter filter)
        {
            return ApplyListAndFilters(filter);
        }

    }
}