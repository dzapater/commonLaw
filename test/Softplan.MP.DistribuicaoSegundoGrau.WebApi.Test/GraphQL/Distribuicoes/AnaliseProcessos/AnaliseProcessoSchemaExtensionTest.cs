using System.Threading.Tasks;
using FluentAssertions;
using GraphQL.Utilities;
using Moq;
using Softplan.Common.Graph.Abstractions;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.AnaliseProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos.Scenarios;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoSchemaExtensionTest : GraphTestBase<AnaliseProcessoFixture>,
        IClassFixture<AnaliseProcessoFixture>
    {
        public AnaliseProcessoSchemaExtensionTest(AnaliseProcessoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task AnalisarProcesso_Por_Prevencao()
        {
            var item = AnaliseProcessoFaker.Entidade.Generate();
            item.TipoDistribuicao = TipoDistribuicao.Prevencao;
            
            var response = await SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                "analisar_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.AreaAtuacao), response, item);
        }
        
        [Fact]
        public async Task AnalisarProcesso_Por_Sorteio()
        {
            var item = AnaliseProcessoFaker.Entidade.Generate();
            item.TipoDistribuicao = TipoDistribuicao.Sorteio;
            
            var response = await SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                "analisar_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.AreaAtuacao), response, item);
        }
        
        [Theory]
        [ClassData(typeof(AnalisarProcessoPorPrevencaoInvalidData))]
        public async Task Analisar_Processo_Por_Prevencao_Invalido(AnaliseProcesso item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                    "analisar_processo", item));

            exception.Message.Should().Contain(containsMessage);
        }
        
        [Theory]
        [ClassData(typeof(AnalisarProcessoPorSorteioInvalidData))]
        public async Task Analisar_Processo_Por_Sorteio_Invalido(AnaliseProcesso item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                    "analisar_processo", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Theory]
        [ClassData(typeof(AnalisarProcessoAtualizadoPorPrevencaoData))]
        public async Task Analisar_Processo_Atualizado_Por_Prevencao(AnaliseProcesso item)
        {
            var response = await SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                "analisar_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata), response, item);
        }
        
        [Theory]
        [ClassData(typeof(AnalisarProcessoAtualizadoPorSorteioData))]
        public async Task AnalisarProcesso_Atualizado_PorSorteio(AnaliseProcesso item)
        {
            var response = await SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                "analisar_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.AreaAtuacao.Nome), response, item);
        }

        [Fact]
        public async Task Get_AnaliseProcesso_PorPrevencao()
        {
            var item = AnaliseProcessoFixture.EntidadeCriadaPorPrevencao;

            var response = await SendQueryAsync<AnaliseProcessoGraphType, AnaliseProcesso>(
                "analise_processo", new {id_processo = item.IdProcesso});

            AssertionHelper.BeEquivalentTo(config
                => config.Excluding(x => x.Metadata), response, item);
        }
        
        [Fact]
        public async Task Get_AnaliseProcesso_PorSorteio()
        {
            var item = AnaliseProcessoFixture.EntidadeAtualizadaPorSorteio;

            var response = await SendQueryAsync<AnaliseProcessoGraphType, AnaliseProcesso>(
                "analise_processo", new {id_processo = item.IdProcesso});

            AssertionHelper.BeEquivalentTo(config
                => config.Excluding(x => x.Metadata)
                    .Excluding(x => x.AreaAtuacao.Nome), response, item);
        }

        [Fact]
        public async Task Save_AnaliseProcesso_LotacaoInvalida()
        {
            var item = AnaliseProcessoFaker.Entidade.Generate();
            item.IdProcesso = "LOTACAO_INVALIDA";

            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                    "analisar_processo", item));

            exception.Message.Should().Contain(DomainResources.LotacaoUsuarioDiferenteLotacaoProcesso);
        }
        
        [Fact]
        public async Task Save_Update_AnaliseProcesso_ProcessoInvalido()
        {
            var item = AnaliseProcessoFaker.Entidade.Generate();
            item.IdProcesso = "PROCESSO_INVALIDO";

            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<AnalisarProcessoInputType, AnaliseProcessoGraphType, AnaliseProcesso>(
                    "analisar_processo", item));

            exception.Message.Should().Contain(DomainResources.ProcessoSigilosoOuInexistente);
        }
    }
}