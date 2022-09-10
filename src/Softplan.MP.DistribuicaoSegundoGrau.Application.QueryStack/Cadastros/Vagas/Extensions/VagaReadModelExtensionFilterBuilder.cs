using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Extensions
{
    public static class VagaReadModelExtensionFilterBuilder
    {
        private static Specification<VagaReadModel> FiltrarPorSituacao(
            this Specification<VagaReadModel> specification, VagaFilter filter)
            => filter.Situacao == null
                ? specification
                : specification.And(new SituacaoVagaReadModelEqualsSpecification(filter.Situacao));
        
        private static Specification<VagaReadModel> FiltrarPorIdMembroAtividade(
            this Specification<VagaReadModel> specification, VagaFilter filter)
            => string.IsNullOrWhiteSpace(filter.IdMembroAtividade)
                ? specification
                : specification.And(new IdMembroAtividadeVagaReadModelEqualsSpecification(filter.IdMembroAtividade));

        public static Expression<Func<VagaReadModel, bool>> ApplyVagaReadModelListFilters(VagaFilter filter)
            => Specification<VagaReadModel>.All
                .FiltrarPorSituacao(filter)
                .FiltrarPorIdMembroAtividade(filter).ToExpression();
        
    }
}