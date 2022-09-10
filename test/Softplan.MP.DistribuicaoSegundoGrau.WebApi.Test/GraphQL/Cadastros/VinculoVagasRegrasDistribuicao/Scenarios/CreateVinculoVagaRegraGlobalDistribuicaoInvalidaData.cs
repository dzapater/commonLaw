using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios
{
    public class CreateVinculoVagaRegraGlobalDistribuicaoInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return RegraGlobalJaVinculadas();
        }
        
        private object[] RegraGlobalJaVinculadas()
        {
            var data = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            data.IdVaga = VinculoVagaRegraDistribuicaoFixture.VagaGlobal.Id;
            data.IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.RegraGlobal2.Id;
            return new object[] {data, DomainResources.RegraGlobalJaVinculadas};
        }
    }
}