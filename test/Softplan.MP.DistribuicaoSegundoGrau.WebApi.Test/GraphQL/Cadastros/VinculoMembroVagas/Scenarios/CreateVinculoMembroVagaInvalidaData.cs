using System;
using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class CreateVinculoMembroVagaInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return VinculoMembroVagaJaCadastrados();
            yield return VinculoMembroVagaPeriodo();
            yield return VinculoMembroVagaDataFinalInvalida();
            
            yield return VinculoMembroVagaEntreVigente();
            yield return VinculoMembroVagaDataInicialEntreVigente();
            yield return VinculoMembroVagaDataFinalEntreVigente();

            yield return PeriodoInformadoAbrangePeriodoVigente();
            yield return PeriodoInformadoAbrangePeriodoVigenteSemDataFinal();
            yield return PeriodoInformadoSemDataFinalAbrangePeriodoVigenteSemDataFinal();
            yield return PeriodoInformadoSemDataFinalAbrangePeriodoVigente();

            yield return PeriodoInformadoComDataInicialIgualDataFinalCadastrada();
            yield return PeriodoInformadoSemDataFinalComDataInicialIgualDataFinalCadastrada();
            yield return PeriodoInformadoComDataFinalIgualDataInicialCadastrada();
            yield return PeriodoInformadoComDataInicialIgualDataInicialCadastradaSemDataFinal();
            yield return PeriodoInformadoComDataFinalIgualDataInicialCadastradaSemDataFinal();
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

        private object[] VinculoMembroVagaPeriodo()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = VinculoMembroVagaFixture.EntidadeInvalida.DataInicial;
            data.DataFinal = VinculoMembroVagaFixture.EntidadeInvalida.DataFinal;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }

        private object[] VinculoMembroVagaDataFinalInvalida()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            data.IdVaga = VinculoMembroVagaFixture.EntidadeInvalida.IdVaga;
            data.DataInicial = DateTimeOffset.Now.Date;
            data.DataFinal = DateTimeOffset.Now.AddDays(-1);
            return new object[] {data, DomainResources.DataFinalMenorDataInicial};
        }

        private object[] VinculoMembroVagaEntreVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(2);
            data.DataFinal = entidadeInvalida.DataFinal?.AddDays(-2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] VinculoMembroVagaDataInicialEntreVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(2);
            data.DataFinal = entidadeInvalida.DataFinal?.AddDays(2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] VinculoMembroVagaDataFinalEntreVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = entidadeInvalida.DataFinal?.AddDays(-2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoAbrangePeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = entidadeInvalida.DataFinal?.AddDays(2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoAbrangePeriodoVigenteSemDataFinal()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalidaSemDataFinal;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = entidadeInvalida.DataInicial.AddDays(2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoSemDataFinalAbrangePeriodoVigenteSemDataFinal()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalidaSemDataFinal;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = null;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoSemDataFinalAbrangePeriodoVigente()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = null;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }

        private object[] PeriodoInformadoComDataInicialIgualDataFinalCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataFinal.GetValueOrDefault().Date;
            data.DataFinal = entidadeInvalida.DataFinal?.AddDays(2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoSemDataFinalComDataInicialIgualDataFinalCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataFinal.GetValueOrDefault().Date;
            data.DataFinal = null;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }

        private object[] PeriodoInformadoComDataFinalIgualDataInicialCadastrada()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalida;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = entidadeInvalida.DataInicial.Date;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoComDataInicialIgualDataInicialCadastradaSemDataFinal()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalidaSemDataFinal;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial;
            data.DataFinal = entidadeInvalida.DataInicial.AddDays(2);
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
        
        private object[] PeriodoInformadoComDataFinalIgualDataInicialCadastradaSemDataFinal()
        {
            var data = VinculoMembroVagaFaker.Entidade.Generate();
            var entidadeInvalida = VinculoMembroVagaFixture.EntidadeInvalidaSemDataFinal;
            data.IdVaga = entidadeInvalida.IdVaga;
            data.DataInicial = entidadeInvalida.DataInicial.AddDays(-2);
            data.DataFinal = entidadeInvalida.DataInicial;
            return new object[] {data, DomainResources.PeriodoInvalido};
        }
    }
}