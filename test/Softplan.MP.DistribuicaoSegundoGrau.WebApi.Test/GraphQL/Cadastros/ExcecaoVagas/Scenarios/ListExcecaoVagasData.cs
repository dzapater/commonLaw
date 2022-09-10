using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas.Scenarios
{
    public class ListExcecaoVagasData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListDataInOrder();
            yield return ListDataByIdVaga();
        }

        private object[] ListDataInOrder()
        {
            Action<ICollection<ExcecaoVaga>, ExcecaoVagaFixture> assert = (items, _) =>
                items.OrderBy(x => x.IdVaga)
                    .Should().BeEquivalentTo(items, opt
                        => opt.WithStrictOrdering());

            return new object[] {assert};
        }

        private object[] ListDataByIdVaga()
        {
            Action<ICollection<ExcecaoVaga>, ExcecaoVagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.IdVaga == ExcecaoVagaFixture.EntidadeCriada.IdVaga).Should().BeTrue();
            };

            string filter = $"IdVaga: \"{ExcecaoVagaFixture.EntidadeCriada.IdVaga}\"";
            return new object[] {assert, filter};
        }
    }
}