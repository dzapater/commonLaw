using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas.Scenarios;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcecaoVagaSchemaExtensionTest : GraphTestBase<ExcecaoVagaFixture>,
        IClassFixture<ExcecaoVagaFixture>
    {
        public ExcecaoVagaSchemaExtensionTest(ExcecaoVagaFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Create_ExcecaoVaga()
        {
            var item = ExcecaoVagaFaker.Entidade.Generate();

            var response = await SendMutationAsync<CreateExcecaoVagaInputType, ExcecaoVagaGraphType, ExcecaoVaga>(
                "create_excecao_vaga", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Id)
                    .Excluding(x => x.IdAssunto)
                    .Excluding(x => x.IdClasse)
                    .Excluding(x => x.IdEspecialidade)
                    .Excluding(x => x.IdOrgaoJulgador)
                    .Excluding(x => x.IdOrigem)
                    .Excluding(x => x.IdUnidade)
                    .Excluding(x => x.Metadata), response, item);
        }
        
        [Theory]
        [ClassData(typeof(CreateExcecaoVagaInvalidaData))]
        public async Task Create_ExcecaoVaga_Invalido(ExcecaoVaga item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateExcecaoVagaInputType, ExcecaoVagaGraphType, ExcecaoVaga>(
                    "create_excecao_vaga", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Theory]
        [ClassData(typeof(UpdateExcecaoVagaData))]
        public async Task Update_ExcecaoVaga(ExcecaoVaga item)
        {
            var response = await SendMutationAsync<UpdateExcecaoVagaInputType, ExcecaoVagaGraphType, ExcecaoVaga>(
                "update_excecao_vaga", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata), response, item);
        }

        [Fact]
        public async Task Delete_ExcecaoVaga()
        {
            var item = ExcecaoVagaFixture.EntidadeRemovida;

            var response = await SendMutationAsync<ExcecaoVaga>(
                "delete_excecao_vaga", new {Id = item.Id}.ToGraphString(), "id");

            response.Id.Should().Be(item.Id);
        }

        [Fact]
        public async Task Get_ExcecaoVaga()
        {
            var item = ExcecaoVagaFixture.EntidadeCriada;

            var response = await SendQueryAsync<ExcecaoVagaGraphType, ExcecaoVaga>(
                "excecao_vaga", new {id = item.Id});

            AssertionHelper.BeEquivalentTo(config
                => config.Excluding(x => x.Metadata), response, item);
        }
        
    }
}