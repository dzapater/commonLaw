using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ImpedimentoProcessos.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos.Scenarios;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoSchemaExtensionTest : GraphTestBase<ImpedimentoProcessoFixture>,
        IClassFixture<ImpedimentoProcessoFixture>
    {
        public ImpedimentoProcessoSchemaExtensionTest(ImpedimentoProcessoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Create_ImpedimentoProcesso()
        {
            var item = ImpedimentoProcessoFaker.Entidade.Generate();
            item.IdVaga = ImpedimentoProcessoFixture.VagaCriada.Id;

            var response = await SendMutationAsync<CreateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType, ImpedimentoProcesso>(
                "create_impedimento_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.IdImpedimento)
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.Vaga), response, item);
        }

        [Theory]
        [ClassData(typeof(CreateImpedimentoProcessoInvalidaData))]
        public async Task Create_ImpedimentoProcesso_Invalido(ImpedimentoProcesso item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType, ImpedimentoProcesso>(
                    "create_impedimento_processo", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Theory]
        [ClassData(typeof(UpdateImpedimentoProcessoData))]
        public async Task Update_ImpedimentoProcesso(ImpedimentoProcesso item)
        {
            var response = await SendMutationAsync<UpdateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType, ImpedimentoProcesso>(
                "update_impedimento_processo", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.Vaga), response, item);
        }

        [Theory]
        [ClassData(typeof(UpdateImpedimentoProcessoInvalidaData))]
        public async Task Update_ImpedimentoProcesso_Invalido(ImpedimentoProcesso item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<UpdateImpedimentoProcessoInputType, ImpedimentoProcessoGraphType, ImpedimentoProcesso>(
                    "update_impedimento_processo", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Delete_ImpedimentoProcesso()
        {
            var item = ImpedimentoProcessoFixture.EntidadeRemovida;

            var response = await SendMutationAsync<ImpedimentoProcesso>(
                "delete_impedimento_processo", new {id_processo = item.IdProcesso, id_impedimento = item.IdImpedimento}.ToGraphString(), "id_processo id_impedimento");

            response.IdProcesso.Should().Be(item.IdProcesso);
            response.IdImpedimento.Should().Be(item.IdImpedimento);
        }

        [Theory]
        [ClassData(typeof(ListImpedimentoProcessosData))]
        public async Task List_ImpedimentoProcessos(Action<ICollection<ImpedimentoProcesso>, ImpedimentoProcessoFixture> assert, string customFilter = default)
        {
            var response = await SendQueryAsync<ImpedimentoProcessoGraphType, ImpedimentoProcesso>(
                "list_impedimentos_processos", 1, 20, customFilter);

            assert(response, Fixture);
        }
    }
}