using System.Collections;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos.Scenarios
{
    public class UpdateImpedimentoProcessoData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            ImpedimentoProcessoFixture.EntidadeAtualizada.Motivo = new Faker().Lorem.Sentences().ClampLength(max: 2000);
            yield return new object[] {ImpedimentoProcessoFixture.EntidadeAtualizada};

            ImpedimentoProcessoFixture.EntidadeAtualizada.IdVaga = ImpedimentoProcessoFixture.EntidadeCriada.IdVaga;
            yield return new object[] {ImpedimentoProcessoFixture.EntidadeAtualizada};
        }
    }
}