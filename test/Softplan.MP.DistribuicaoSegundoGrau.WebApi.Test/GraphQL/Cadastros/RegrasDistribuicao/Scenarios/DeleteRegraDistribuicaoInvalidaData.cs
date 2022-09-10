using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao.Scenarios
{
    public class DeleteRegraDistribuicaoInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {RegraDistribuicaoFixture.RegraJaDistribuida, DomainResources.RegraUtilizadaNaDistribuicao};
        }
    }
}