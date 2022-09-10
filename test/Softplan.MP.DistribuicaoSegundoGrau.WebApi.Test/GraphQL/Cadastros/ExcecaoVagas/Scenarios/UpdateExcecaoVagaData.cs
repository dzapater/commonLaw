using System.Collections;
using System.Collections.Generic;
using Bogus;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas.Scenarios
{
    public class UpdateExcecaoVagaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            ExcecaoVagaFixture.EntidadeAtualizada.IdVaga = new Faker().Random.Int(2,999);
            yield return new object[] {ExcecaoVagaFixture.EntidadeAtualizada};
        }
    }
}