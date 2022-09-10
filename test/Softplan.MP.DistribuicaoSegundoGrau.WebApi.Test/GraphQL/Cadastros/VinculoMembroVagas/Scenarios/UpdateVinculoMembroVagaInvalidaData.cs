using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class UpdateVinculoMembroVagaInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return VinculoMembroVagaJaCadastrados();
            
            yield return PeridoInformadoEntreVigente();
            yield return DataInicialInformadaEntrePeriodoVigente();
            yield return DataFinalInformadaEntrePeriodoVigente();

            yield return PeridoInformadoContemPeriodoVigente();
            yield return PeridoInformadoSemDataFinalContemPeriodoVigente();

            yield return DataInicialInformadaIgualDataInicialCadastrada();
            yield return DataInicialInformadaIgualDataFinalCadastrada();
            yield return DataFinalInformadaIgualDataInicialCadastrada();
            yield return DataFinalInformadaIgualDataFinalCadastrada();
            
            yield return new object[] {VinculoMembroVagaFixture.EntidadeAtualizadaVinculoVencido, DomainResources.PeriodoInvalido};
        }
        
        private object[] VinculoMembroVagaJaCadastrados()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.IdMembro = VinculoMembroVagaFixture.EntidadeInvalida.IdMembro;
            data.IdMotivoMembroVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdMotivoMembroVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial;
            return new object[] {data, DomainResources.InformacoesJaVinculadas};
        }

        private object[] PeridoInformadoEntreVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(-1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataInicialInformadaEntrePeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataFinalInformadaEntrePeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(-1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(-1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeridoInformadoContemPeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(-1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        } 
        
        private object[] PeridoInformadoSemDataFinalContemPeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(-1);
            data.DataFinal = null;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataInicialInformadaIgualDataInicialCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial;
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataInicialInformadaIgualDataFinalCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal.GetValueOrDefault().Date;
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal?.AddDays(1);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataFinalInformadaIgualDataInicialCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(-1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] DataFinalInformadaIgualDataFinalCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial.AddDays(-1);
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
    }
}