using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas.Scenarios;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas
{
    public class VagaSchemaExtensionTest : GraphTestBase<VagaFixture>,
        IClassFixture<VagaFixture>
    {
        public VagaSchemaExtensionTest(VagaFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Create_Vaga()
        {
            var item = VagaFaker.Entidade.Generate();
            var response = await SendMutationAsync<CreateVagaInputType, VagaGraphType, Vaga>("create_vaga", item);            

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Id)
                    .Excluding(x => x.CdLocal)
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.Orgao), response, item);
        }

        [Theory]
        [ClassData(typeof(CreateVagaInvalidaData))]
        public async Task Create_Vaga_Invalida(Vaga item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateVagaInputType, VagaGraphType, Vaga>(
                    "create_vaga", item));

            exception.Message.Should().Contain(containsMessage);
        }
        
        [Theory]
        [ClassData(typeof(UpdateVagaData))]
        public async Task Update_Vaga(Vaga item)
        {
            var response = await SendMutationAsync<UpdateVagaInputType, VagaGraphType, Vaga>(
                "update_vaga", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.CdLocal)
                    .Excluding(x => x.Orgao), response, item);
        }
        
        [Theory]
        [ClassData(typeof(UpdateVagaInvalidaData))]
        public async Task Update_Vaga_Invalida(Vaga item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<UpdateVagaInputType, VagaGraphType, Vaga>(
                    "update_vaga", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Delete_Vaga()
        {
            var item = VagaFixture.VagaRemovida;

            var response = await SendMutationAsync<Vaga>(
                "delete_vaga", new {id = item.Id}.ToGraphString(), "id");

            response.Id.Should().Be(item.Id);
        }

        
        [Fact]
        public async Task GetVaga()
        {
            var item = VagaFixture.VagaCriada;

            var response = await SendQueryAsync<VagaGraphType, Vaga>(
                "vaga", new {id = item.Id});

            AssertionHelper.BeEquivalentTo(config
                => config.Excluding(x => x.Metadata)
                         .Excluding(x => x.CdLocal)
                         .Excluding(x => x.Orgao), response, item);
        }

        [Theory]
        [ClassData(typeof(ListVagaData))]
        public async Task ListVaga(Action<ICollection<VagaReadModel>, VagaFixture> assert, string customFilter = default)
        {
            var countVagas = await Fixture.DbContext.Set<Vaga>().AsNoTracking().CountAsync();
            var response = await SendQueryAsync<VagaListItemGraphType, VagaReadModel>(
                "list_vagas", 1, countVagas, customFilter);

            assert(response, Fixture);
        }
    }
}