using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas.Scenarios
{
    public class DeleteVagaInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {VagaFixture.VagaRemovida, DomainResources.VagaEmUso};
        }
    }
}