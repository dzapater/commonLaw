using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaSchemaExtensionTest : GraphTestBase<VinculoMembroVagaFixture>,
        IClassFixture<VinculoMembroVagaFixture>
    {
        private readonly VinculoMembroVagaFixture _fixture;
        
        public VinculoMembroVagaSchemaExtensionTest(VinculoMembroVagaFixture fixture) : base(fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(CreateVinculoMembroVagaData))]
        public async Task Create_VinculoMembroVaga(VinculoMembroVaga item)
        {
            var response = await SendMutationAsync<CreateVinculoMembroVagaInputType, VinculoMembroVagaGraphType, VinculoMembroVaga>(
                "create_vinculo_membro_vaga", item);

            AssertionHelper.BeEquivalentTo(config
                => config.Excluding(x => x.Metadata)
                    .Excluding(x => x.Id)
                    .Excluding(x => x.Vaga)
                    .Excluding(x => x.DataFinal)
                , response, item);
        }
        
        [Theory]
        [ClassData(typeof(CreateVinculoMembroVagaInvalidaData))]
        public async Task Create_VinculoMembroVaga_Invalido(VinculoMembroVaga item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateVinculoMembroVagaInputType, VinculoMembroVagaGraphType, VinculoMembroVaga>(
                    "create_vinculo_membro_vaga", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Create_VinculoMembroVaga_PeriodoInvalido()
        {
            var vaga = VagaFaker.Entidade.Generate();
            _fixture.DbContext.Add(vaga);
            var vinculo = VinculoMembroVagaFaker.Entidade.Generate();
            vinculo.Vaga = vaga;
            vinculo.IdVaga = vaga.Id;
            vinculo.DataInicial = DateTimeOffset.Now;
            vinculo.DataFinal = DateTimeOffset.Now.AddDays(2);
            _fixture.DbContext.Add(vinculo);
            _fixture.DbContext.SaveChanges();

            var vinculoTeste = VinculoMembroVagaFaker.Entidade.Generate();
            vinculoTeste.IdVaga = vaga.Id;
            vinculoTeste.DataInicial = DateTimeOffset.Now.AddDays(2);
            vinculoTeste.DataFinal = null;
            
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateVinculoMembroVagaInputType, VinculoMembroVagaGraphType, VinculoMembroVaga>(
                    "create_vinculo_membro_vaga", vinculoTeste));

            exception.Message.Should().Contain("O periodo informado é invalido");
        }

        [Fact]
        public async Task Update_VinculoMembroVaga()
        {
            var item = VinculoMembroVagaFixture.EntidadeAtualizada;
            item.IdMotivoMembroVaga += 1;
            
            var response = await SendMutationAsync<UpdateVinculoMembroVagaInputType, VinculoMembroVagaGraphType,
                    VinculoMembroVaga>("update_vinculo_membro_vaga", item);
            
            AssertionHelper.BeEquivalentTo(config
                    => config.Excluding(x => x.Metadata)
                        .Excluding(x => x.Vaga), response, item);
        }
        
        [Theory]
        [ClassData(typeof(UpdateVinculoMembroVagaInvalidaData))]
        public async Task Update_VinculoMembroVaga_Invalido(VinculoMembroVaga item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<UpdateVinculoMembroVagaInputType, VinculoMembroVagaGraphType,
                    VinculoMembroVaga>("update_vinculo_membro_vaga", item));

            exception.Message.Should().Contain(containsMessage);
        }
        
        [Fact]
        public async Task Delete_VinculoMembroVaga()
        {
            var item = VinculoMembroVagaFixture.EntidadeRemovida;
            var response = await SendMutationAsync<VinculoMembroVaga>(
                "delete_vinculo_membro_vaga", new {id = item.Id, IdVaga = item.IdVaga,IdMembro=item.IdMembro}.ToGraphString(), "id, id_vaga, id_membro");

            response.Id.Should().Be(item.Id);
            response.IdVaga.Should().Be(item.IdVaga);
            response.IdMembro.Should().Be(item.IdMembro);
            
        }

        [Theory]
        [ClassData(typeof(ListVinculoMembroVagasData))]
        public async Task List_VinculoMembroVagas(Action<ICollection<VinculoMembroVagaReadModel>, VinculoMembroVagaFixture> assert, string customFilter = default )
        {
            var response = await SendQueryAsync<VinculoMembroVagaListItemGraphType, VinculoMembroVagaReadModel>(
                "list_vinculo_membro_vaga", 1, 20, customFilter);

            assert(response, Fixture);
        }
    }
}