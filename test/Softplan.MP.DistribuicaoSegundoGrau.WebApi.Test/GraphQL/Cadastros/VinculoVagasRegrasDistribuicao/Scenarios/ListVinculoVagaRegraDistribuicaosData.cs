using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios
{
    public class ListVinculoVagaRegraDistribuicaosData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListData();
            yield return ListDataInOrderByVaga();
            yield return ListDataInOrderByRegra();
            yield return ListDataByVaga();
            yield return ListDataByRegra();
            yield return ListDataByDescricaoVaga();
            yield return ListDataByDescricaoRegra();
        }

        private object[] ListData()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
                items.Should().NotBeEmpty();

            return new object[] {assert};
        }

        private object[] ListDataInOrderByVaga()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.Vaga.Descricao);

            var filter = $"id_regra_distribuicao: {VinculoVagaRegraDistribuicaoFixture.RegraAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataInOrderByRegra()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
                items.Should().BeInAscendingOrder(x => x.RegraDistribuicao.Descricao);

            var filter = $"id_vaga: {VinculoVagaRegraDistribuicaoFixture.VagaAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataByVaga()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Vaga.Id.Equals(VinculoVagaRegraDistribuicaoFixture.VagaAtiva.Id))
                    .Should().BeTrue();
            };

            var filter = $"id_vaga: {VinculoVagaRegraDistribuicaoFixture.VagaAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataByRegra()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.RegraDistribuicao.Id.Equals(VinculoVagaRegraDistribuicaoFixture.RegraAtiva.Id))
                    .Should().BeTrue();
            };

            var filter = $"id_regra_distribuicao: {VinculoVagaRegraDistribuicaoFixture.RegraAtiva.Id}";
            return new object[] {assert, filter};
        }

        private object[] ListDataByDescricaoVaga()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Vaga.Descricao
                        .Contains(VinculoVagaRegraDistribuicaoFixture.VagaAtiva.Descricao, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{VinculoVagaRegraDistribuicaoFixture.VagaAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }

        private object[] ListDataByDescricaoRegra()
        {
            Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.RegraDistribuicao.Descricao
                        .Contains(VinculoVagaRegraDistribuicaoFixture.RegraAtiva.Descricao, StringComparison.OrdinalIgnoreCase))
                    .Should().BeTrue();
            };

            var filter = $"busca: \"{VinculoVagaRegraDistribuicaoFixture.RegraAtiva.Descricao}\"";
            return new object[] {assert, filter};
        }
    }
}