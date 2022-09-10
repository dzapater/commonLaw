using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class ListVinculoMembroVagasData : IEnumerable<object[]>
    {
           IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListData();
            yield return ListDataInOrderByVaga();
            
            yield return ListDataByVaga();
            yield return ListDataByMembro();
            yield return ListDataByDescricaoVaga();
            yield return ListDataByObservacao();
        }

        private object[] ListData()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
                items.Should().NotBeEmpty();

            return new object[] {assert};
        }

        private object[] ListDataInOrderByVaga()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Vaga.Descricao);

            var filter = $"id_vaga: {VinculoMembroVagaFixture.VagaAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataByVaga()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Vaga.Id.Equals(VinculoMembroVagaFixture.VagaAtiva.Id))
                    .Should().BeTrue();
            };

            var filter = $"id_vaga: {VinculoMembroVagaFixture.VagaAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataByMembro()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
            {
                
                items.All(x => x.IdMembro
                        .Contains(VinculoMembroVagaFixture.EntidadeCriada.IdMembro, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{VinculoMembroVagaFixture.EntidadeCriada.IdMembro}\"";
            return new object[] {assert, filter};
        }
        
        
        private object[] ListDataByObservacao()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
            {
                
                items.All(x => x.Observacao
                        .Contains(VinculoMembroVagaFixture.EntidadeCriada.Observacao, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{VinculoMembroVagaFixture.EntidadeCriada.Observacao}\"";
            return new object[] {assert, filter};
        }
        

        private object[] ListDataByDescricaoVaga()
        {
            Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Vaga.Descricao
                        .Contains(VinculoMembroVagaFixture.VagaAtiva.Descricao, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{VinculoMembroVagaFixture.VagaAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }
    }
}