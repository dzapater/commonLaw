using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using GraphQL.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Parametros;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DistribuicaoProcessos.Scenarios;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcessoMutationSchemaExtensionIntegrationTest : GraphTestBase<DistribuicaoProcessoFixture>,
        IClassFixture<DistribuicaoProcessoFixture>
    {
        public DistribuicaoProcessoMutationSchemaExtensionIntegrationTest(DistribuicaoProcessoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Distribuir_Processo_Por_Prevencao()
        {
            var item = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();
            item.IdProcesso = DistribuicaoProcessoFixture.ImpedimentoProcesso.IdProcesso;
            item.TipoDistribuicao = TipoDistribuicao.Prevencao;
            item.IdVaga = DistribuicaoProcessoFixture.VagaDistribuicao.Id;

            var response = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", item);

            response.Exception.Should().BeNull();
            response.IsCompleted.Should().BeTrue();
            response.IdProcesso.Should().Be(item.IdProcesso);
            response.TransactionId.Should().NotBe(Guid.Empty);

            ValidarAnalise(item);

            var record = Fixture.DbContext.Set<DistribuicaoProcesso>()
                .Include(x => x.Logs)
                .Single(x => x.IdProcesso.Equals(item.IdProcesso));

            record.Should().NotBeNull();
            record.Logs.Should().HaveCount(3);
            record.Logs.All(x => x.TransactionId == response.TransactionId).Should().BeTrue();
            record.Logs.Single(x => x.DomainEvent is ProcessoFoiDistribuidoPorPrevencao).Should().NotBeNull();
            record.Logs.Single(x => x.DomainEvent is VagaFoiSelecionadaParaDistribuicao).Should().NotBeNull();
            record.Logs.Single(x => x.DomainEvent is RemessaProcessoFoiAgendada).Should().NotBeNull();
        }
        
        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Distribuicao_Processo_E_Nao_Possuir_PrevencaoPrevia_Entao_Distribuir_Processo_Por_Sorteio_Eh_Satisfeito()
        {
            var sut = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();
            sut.IdProcesso = DistribuicaoProcessoFixture.AnaliseProcessoFluxoSorteioOuPrevencao.IdProcesso;
            sut.IdVaga = DistribuicaoProcessoFixture.VagaDistribuicaoFluxoSorteioOuPrevencao.Id;
            sut.TipoDistribuicao = TipoDistribuicao.Sorteio;            

            var response = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", sut);

            response.Exception.Should().BeNull();
            response.IsCompleted.Should().BeTrue();
            response.IdProcesso.Should().Be(sut.IdProcesso);
            response.TransactionId.Should().NotBe(Guid.Empty);

            ValidarAnaliseFluxoPrevencaoOuSorteio(sut);

            var record = Fixture.DbContext.Set<DistribuicaoProcesso>()
                .Include(x => x.Logs)
                .Single(x => x.IdProcesso.Equals(sut.IdProcesso));

            record.Should().NotBeNull();
            record.Logs.Should().HaveCount(3);
            record.Logs.All(x => x.TransactionId == response.TransactionId).Should().BeTrue();
            record.Logs.Single(x => x.DomainEvent is ProcessoFoiDistribuidoPorSorteio).Should().NotBeNull();
            record.Logs.Single(x => x.DomainEvent is VagaFoiSelecionadaParaDistribuicao).Should().NotBeNull();
            record.Logs.Single(x => x.DomainEvent is RemessaProcessoFoiAgendada).Should().NotBeNull();
        }

        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Distribuicao_Processo_Possuir_DistribuicaoPrevia_Entao_Distribuir_Processo_Por_Prevencao_Eh_Satisfeito()
        {
            var sut = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();            
            sut.IdProcesso = DistribuicaoProcessoFixture.AnaliseProcessoFluxoSorteioOuPrevencao2.IdProcesso;
            sut.IdVaga = DistribuicaoProcessoFixture.VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            sut.TipoDistribuicao = TipoDistribuicao.Sorteio;

            var response = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", sut);

            response.Exception.Should().BeNull();
            response.IsCompleted.Should().BeTrue();
            response.IdProcesso.Should().Be(sut.IdProcesso);
            response.TransactionId.Should().NotBe(Guid.Empty);

            ValidarAnaliseFluxoPrevencaoOuSorteio(sut);

            var record = Fixture.DbContext.Set<DistribuicaoProcesso>()
                .Include(x => x.Logs)
                .OrderByDescending(x =>x.Id)                
                .FirstOrDefault(x => x.TipoDistribuicao.Equals(TipoDistribuicao.Prevencao));

            record.Should().NotBeNull();
            record.Logs.Should().HaveCount(3);
            record.Logs.All(x => x.TransactionId == response.TransactionId).Should().BeTrue();
            record.Logs.Single(x => x.DomainEvent is ProcessoFoiDistribuidoPorPrevencao).Should().NotBeNull();            
            record.Logs.Single(x => x.DomainEvent is VagaFoiSelecionadaParaDistribuicao).Should().NotBeNull();
            record.Logs.Single(x => x.DomainEvent is RemessaProcessoFoiAgendada).Should().NotBeNull();
        }
        
        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Distribuicao_Processo_Possuir_Impedimento_Entao_Distribuir_Processo_Por_Prevencao_Eh_Satisfeito()
        {
            var sut = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();
            sut.IdProcesso = "PROCESSO_VAGA_IMPEDIDA";            
            sut.IdVaga = DistribuicaoProcessoFixture.VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            sut.TipoDistribuicao = TipoDistribuicao.Sorteio;

            var response = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", sut);

            response.Exception.Should().BeNull();
            response.IsCompleted.Should().BeTrue();
            response.IdProcesso.Should().Be(sut.IdProcesso);
            response.TransactionId.Should().NotBe(Guid.Empty);

            ValidarImpedimentoPrevencaoOuSorteio(sut);

            var record = Fixture.DbContext.Set<ImpedimentoDistribuicaoLog>()
                .FirstOrDefault(x => x.IdProcesso.Equals(response.IdProcesso));

            record.Should().NotBeNull();
            record.TransactionId.Should().Be(response.TransactionId); 
            record.PayloadType.Should().Contain(nameof(VagasForamImpedidasParaDistribuicao));
        }
        
        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Vaga_DistribuicaoProcesso_PossuirExcecao_Entao_Distribuir_Processo_Nao_Eh_Satisfeito()
        {
                var request = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();
                request.IdProcesso = "idProcessoExcecaoo";
                request.TipoDistribuicao = TipoDistribuicao.Sorteio;

                var sut =
                    await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType,
                        DistribuirProcessoResponse>(
                        "distribuir_processo", request);
                
                var assert = Fixture.DbContext.Set<ImpedimentoDistribuicaoLog>()
                    .FirstOrDefault(x => x.IdProcesso.Equals(sut.IdProcesso) && x.PayloadType.Contains(nameof(ProcessoVagasComExcecao)));

                assert.Should().NotBeNull();
        }
        
        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Vaga_DistribuicaoProcesso_PossuirDistribuicaoMesmaVaga_Entao_Distribuir_Processo_Nao_Eh_Satisfeito()
        {
            var request = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();            
            request.IdProcesso = "idProcessoVagaJaDistribuida";
            request.TipoDistribuicao = TipoDistribuicao.Sorteio;
            var sut = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", request);

            sut.Exception.Should().BeNull();
            sut.IsCompleted.Should().BeTrue();
            sut.IdProcesso.Should().Be(sut.IdProcesso);
            sut.TransactionId.Should().NotBe(Guid.Empty);

            var assert = Fixture.DbContext.Set<ImpedimentoDistribuicaoLog>()
                .FirstOrDefault(x => x.PayloadType.Contains(nameof(ProcessoVagasRemovidasDistribuicaoMesmaVaga)));

            assert.Should().NotBeNull();
        }

        [Fact]
        public async Task Dado_Processo_Por_Sorteio_Quando_Vaga_DistribuicaoProcesso_PossuirDesvioInvalido_Entao_Distribuir_Processo_Nao_Eh_Satisfeito()
        {
            var request = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();            
            request.IdProcesso = "idProcessoDesvio";
            request.TipoDistribuicao = TipoDistribuicao.Sorteio;
            
            var sut = await SendMutationAsync<RequestDistribuirProcessoInputType, ResponseDistribuirProcessoGraphType, DistribuirProcessoResponse>(
                "distribuir_processo", request);
                
            sut.Exception.Should().BeNull();
            sut.IsCompleted.Should().BeTrue();
            sut.IdProcesso.Should().Be(sut.IdProcesso);
            sut.TransactionId.Should().NotBe(Guid.Empty);

            var assert = Fixture.DbContext.Set<ImpedimentoDistribuicaoLog>()
                .FirstOrDefault(x => x.PayloadType.Contains(nameof(VagasRemovidasParaDistribuicaoCriterioDesvio)));

            assert.Should().NotBeNull();
        }
        
        [Theory]
        [ClassData(typeof(ListDistribuicaoProcessoData))]
        public async Task List_Distribuicao_Processo(Action<ICollection<DistribuicaoProcessoReadModel>, DistribuicaoProcessoFixture> assert, string customFilter = default)
        {
            var response = await SendQueryAsync<DistribuicaoProcessoReadModelGraphType, DistribuicaoProcessoReadModel>(
                "consulta_distribuicao_processo", 1, 20, customFilter);

            assert(response, Fixture);
        }

        private void ValidarAnalise(DistribuirProcessoRequest distribuicao)
        {
            var record = Fixture.DbContext.Set<AnaliseProcesso>()
                .Single(x => x.IdProcesso.Equals(distribuicao.IdProcesso));
            record.IdVaga.Should().Be(distribuicao.IdVaga);
            record.Motivo.Should().Be(distribuicao.Motivo);
        }

        private void ValidarAnaliseFluxoPrevencaoOuSorteio(DistribuirProcessoRequest distribuicao)
        {
            var record = Fixture.DbContext.Set<AnaliseProcesso>()
                .Single(x => x.IdProcesso.Equals(distribuicao.IdProcesso));
            record.IdProcesso.Should().Be(distribuicao.IdProcesso);            
        }
        
        private void ValidarImpedimentoPrevencaoOuSorteio(DistribuirProcessoRequest distribuicao)
        {
            var record = Fixture.DbContext.Set<ImpedimentoDistribuicaoLog>()
                .FirstOrDefault(x => x.IdProcesso.Equals(distribuicao.IdProcesso));
            record.IdProcesso.Should().Be(distribuicao.IdProcesso);            
        }
    }
}