using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class ListMotivoMembroVagasData : IEnumerable<object[]>
    {
           IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListDataInOrderById();
            
            yield return ListDataInOrderByAtivo();
            
            yield return ListDataInOrderByDescricao();
            
            yield return ListDataById();
            
            yield return ListDataByAtivo();
        
            yield return ListDataByDescricao();
        }
        private object[] ListDataInOrderById()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Id);

            var filter = $"busca: \"{MotivoMembroVagaFixture.EntidadeAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListDataInOrderByAtivo()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Ativo);

            var filter = $"busca: \"{MotivoMembroVagaFixture.EntidadeAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListDataInOrderByDescricao()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Descricao);

            var filter = $"busca: \"{MotivoMembroVagaFixture.EntidadeAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }

        private object[] ListDataById()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Id);

            var filter = $"id: {MotivoMembroVagaFixture.EntidadeAtiva.Id}";
            return new object[] {assert, filter};
        }
        
        private object[] ListDataByAtivo()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
            {
                items.All(x => x.Ativo
                        .Equals(MotivoMembroVagaFixture.EntidadeAtiva.Ativo, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };
            
            
            var filter = $"ativo: \"{MotivoMembroVagaFixture.EntidadeAtiva.Ativo}\"";
            return new object[] {assert, filter};
        }

        private object[] ListDataByDescricao()
        {
            Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert = (items, _) =>
            {
                items.All(x => x.Descricao
                        .Contains(MotivoMembroVagaFixture.EntidadeAtiva.Descricao, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{MotivoMembroVagaFixture.EntidadeAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }
    }
}