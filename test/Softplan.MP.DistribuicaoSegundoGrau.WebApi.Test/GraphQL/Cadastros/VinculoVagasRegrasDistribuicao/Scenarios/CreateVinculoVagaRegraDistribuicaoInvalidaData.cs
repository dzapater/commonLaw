using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios
{
    public class CreateVinculoVagaRegraDistribuicaoInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return RegraGlobalJaVinculadas();
            yield return InformacoesJaVinculadas();
        }

        private object[] InformacoesJaVinculadas()
        {
            var data = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            data.IdVaga = VinculoVagaRegraDistribuicaoFixture.EntidadeCriada.IdVaga;
            data.IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.EntidadeCriada.IdRegraDistribuicao;
            return new object[] {data, DomainResources.InformacoesJaVinculadas};
        }
        
        private object[] RegraGlobalJaVinculadas()
        {
            var data = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            data.IdVaga = VinculoVagaRegraDistribuicaoFixture.EntidadeGlobal.IdVaga;
            data.IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.RegraGlobal2.Id;
            return new object[] {data, DomainResources.RegraGlobalJaVinculadas};
        }
    }
}