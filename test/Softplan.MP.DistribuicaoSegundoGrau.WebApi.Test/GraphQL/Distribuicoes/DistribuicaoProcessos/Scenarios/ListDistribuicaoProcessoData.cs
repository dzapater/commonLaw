using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DistribuicaoProcessos.Scenarios
{
    public class ListDistribuicaoProcessoData : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return ListDataByIdProcesso();
            }

            private object[] ListDataByIdProcesso()
            {
                var distribuicao = DistribuicaoProcessoReadModelFaker.RequestCriarDistribuicaoProcesso.Generate();
                Action<ICollection<DistribuicaoProcessoReadModel>, DistribuicaoProcessoFixture> assert = async (items, fixture) =>
                {
                    await fixture.DbContext.AddAsync(distribuicao.DistribuicaoProcesso);
                    await fixture.DbContext.SaveChangesAsync();
                    items.All(x => x.DistribuicaoProcesso.IdProcesso == DistribuicaoProcessoFixture.DistribuicaoReadModelFaker.DistribuicaoProcesso.IdProcesso).Should().BeTrue();
                };

                string filter = $"id_processo: \"{DistribuicaoProcessoFixture.DistribuicaoReadModelFaker.DistribuicaoProcesso.IdProcesso}\"";
                return new object[] {assert, filter};
            }
        }
    }
