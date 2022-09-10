using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos.Scenarios
{
    public class ListImpedimentoProcessosData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListDataByProcesso();
            yield return ListDataByProcessoVaga();
        }

        private object[] ListDataByProcesso()
        {
            Action<ICollection<ImpedimentoProcesso>, ImpedimentoProcessoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.IdProcesso.Equals(ImpedimentoProcessoFixture.EntidadeCriada.IdProcesso)).Should().BeTrue();
            };

            string filter = $"id_processo: \"{ImpedimentoProcessoFixture.EntidadeCriada.IdProcesso}\"";
            return new object[] {assert, filter};
        }

        private object[] ListDataByProcessoVaga()
        {
            Action<ICollection<ImpedimentoProcesso>, ImpedimentoProcessoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x =>
                        x.IdProcesso.Equals(ImpedimentoProcessoFixture.EntidadeCriada.IdProcesso) &&
                        x.IdVaga.Equals(ImpedimentoProcessoFixture.EntidadeCriada.IdVaga))
                    .Should().BeTrue();
            };

            string filter = $"id_processo: \"{ImpedimentoProcessoFixture.EntidadeCriada.IdProcesso}\" id_vaga: {ImpedimentoProcessoFixture.EntidadeCriada.IdVaga}";
            return new object[] {assert, filter};
        }
    }
}