using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios
{
    public class RegistraCompensacaoInvalidData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return RegraInvalida();
            yield return CompensacaoInvalida();
            yield return MotivoInvalido();
        }
        
        private object[] RegraInvalida()
        {
            var data = new
            {
                IdRegraDistribuicao = 0,
                Motivo = "Teste",
                Vagas = new[] { new { VinculoVagaRegraDistribuicaoFixture.RegraRegistraCompensacao.Id, Compensacao = 10 } }
            };
            return new object[] {data, DomainResources.RegraInvalida};
        }
        
        private object[] CompensacaoInvalida()
        {
            var data = new
            {
                IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.RegraRegistraCompensacao.Id,
                Motivo = "Teste",
                Vagas = new[] { new
                {
                    VinculoVagaRegraDistribuicaoFixture.VagaRegistraCompensacao.Id, 
                    Compensacao = int.MaxValue
                } }
            };
            return new object[] {data, DomainResources.ValorCompensacaoMaior};
        }
        
        private object[] MotivoInvalido()
        {
            var data = new
            {
                IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.RegraRegistraCompensacao.Id,
                Motivo = "",
                Vagas = new[] { new
                {
                    VinculoVagaRegraDistribuicaoFixture.VagaRegistraCompensacao.Id, 
                    Compensacao = 0
                } }
            };
            return new object[] {data, DomainResources.MotivoIncorreto};
        }
    }
}