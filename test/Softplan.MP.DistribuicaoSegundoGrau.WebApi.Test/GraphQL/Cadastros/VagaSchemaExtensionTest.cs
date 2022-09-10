using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Clients;
using Softplan.Common.Test.AspNetCore.GraphQL.DataTransferObjects;
using Softplan.Common.Test.AspNetCore.Templates;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros
{
    /// <summary>
    /// 
    /// </summary>
    public class VagaSchemaExtensionTest : GraphQLTestBase<Vaga, IdVaga, Startup>,
        IClassFixture<TestServerFixture>
    {
        public VagaSchemaExtensionTest(TestServerFixture fixture) :
            base(fixture, new RootFieldNames("vaga", "vagas"))
        {
            fixture.ConfigureServices = (_, services) => services.AddSingleton(__ => VagaFaker.Vaga);
        }

        [Fact]
        public async Task When_Get_By_Id_Return_Should_be_Success() =>
            await SendGetByIdAsync<Vaga, VagaGraphType>(new Mock<Vaga>(1), assertItem =>
                AssertionHelper.BeEquivalentTo(config => config
                    .Excluding(x => x.Metadata), assertItem.databaseModel, assertItem.response)
                );
        
        [Fact]
        public async Task When_Save_All_Fields_Return_Should_Be_Success()
        {
            await SendCreateAsync<Vaga, CreateVagaInputType, Vaga, VagaGraphType>(
                () => Context.Faker.Generate(), equivalency
                    => equivalency.Excluding(x => x.Id)
                        .Excluding(x => x.Metadata));
        }

        [Fact]
        public async Task When_Save_Invalid_Name_Return_Should_Be_Fail() =>
            await SendInvalidCreateAsync<Vaga, CreateVagaInputType>(() =>
                {
                    var fake = Context.Faker.Generate();
                    fake.Descricao = string.Empty;
                    fake.IdTipoOrgao = 0;
                    fake.IdOrgao = 0;
                    fake.IdInstalacao = 0;
                    fake.IdProcuradorTitular = 0;
                    return fake;
                },
                (tuple) =>
                {
                    var message = tuple.response.Errors.First().Message;
                    message.Should().NotBeNullOrEmpty();
                });

        [Fact]
        public async Task When_Update_Invalid_Nome_Return_Should_Be_Fail() =>
            await SendInvalidUpdateAsync<Vaga, UpdateVagaInputType>(
                fake =>
                {
                    fake.Descricao = string.Empty;
                    fake.IdTipoOrgao = 0;
                    fake.IdOrgao = 0;
                    fake.IdInstalacao = 0;
                    fake.IdProcuradorTitular = 0;
                },
                (tuple) =>
                {
                    var message = tuple.response.Errors.First().Message;
                    message.Should().NotBeNullOrEmpty();
                });

        
        [Fact]
        public async Task When_Delete_By_Id_Return_Should_be_Success() =>
            await SendDeleteAsync<Vaga, VagaGraphType>();
    }
}