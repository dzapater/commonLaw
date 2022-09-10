using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios
{
    public class ListHistoricoCompensacaoData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListData();
            yield return ListDataInOrderDescending();
        }
        
        private object[] ListData()
        {
            Action<ICollection<HistoricoCompensacaoRegraReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
                items.Count().Should().BeGreaterThan(0);

            return new object[] {assert};
        }

        private object[] ListDataInOrderDescending()
        {
            Action<ICollection<HistoricoCompensacaoRegraReadModel>, VinculoVagaRegraDistribuicaoFixture> assert = (items, _) =>
                items.OrderByDescending(x => x.DataRegistro)
                    .ThenBy(x => x.Descricao)
                    .Should().BeEquivalentTo(items, opt
                        => opt.WithStrictOrdering());

            return new object[] {assert};
        }
    }
}

        
