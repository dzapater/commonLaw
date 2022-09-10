using System.Collections;
using System.Collections.Generic;
using Bogus;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos.Scenarios
{
    public class AnalisarProcessoAtualizadoPorPrevencaoData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            AnaliseProcessoFixture.EntidadeAtualizadaPorPrevencao.Motivo = new Faker().Lorem.Sentences(2);
            AnaliseProcessoFixture.EntidadeAtualizadaPorPrevencao.IdVaga += 1;
            yield return new object[] {AnaliseProcessoFixture.EntidadeAtualizadaPorPrevencao};
        }
    }
}