using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao.Scenarios;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoSchemaExtensionTest : GraphTestBase<VinculoVagaRegraDistribuicaoFixture>,
        IClassFixture<VinculoVagaRegraDistribuicaoFixture>
    {
        public VinculoVagaRegraDistribuicaoSchemaExtensionTest(VinculoVagaRegraDistribuicaoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Create_VinculoVagaRegraDistribuicao()
        {
            var item = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            item.IdVaga = VinculoVagaRegraDistribuicaoFixture.VagaCriacao.Id;
            item.IdRegraDistribuicao = VinculoVagaRegraDistribuicaoFixture.RegraCriacao.Id;

            var response = await SendMutationAsync<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType, VinculoVagaRegraDistribuicao>(
                "create_vinculo_vaga_regra_distribuicao", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Metadata), response, item);
        }

        [Theory]
        [ClassData(typeof(CreateVinculoVagaRegraDistribuicaoInvalidaData))]
        public async Task Create_VinculoVagaRegraDistribuicao_Invalido(VinculoVagaRegraDistribuicao item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType, VinculoVagaRegraDistribuicao>(
                    "create_vinculo_vaga_regra_distribuicao", item));

            exception.Message.Should().Contain(containsMessage);
        }
        
        [Theory]
        [ClassData(typeof(CreateVinculoVagaRegraGlobalDistribuicaoInvalidaData))]
        public async Task Create_VinculoVagaRegraDistribuicao_RegraGlobal_Invalido(VinculoVagaRegraDistribuicao item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType, VinculoVagaRegraDistribuicao>(
                    "create_vinculo_vaga_regra_distribuicao", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Delete_VinculoVagaRegraDistribuicao()
        {
            var item = VinculoVagaRegraDistribuicaoFixture.EntidadeRemovida;

            var response = await SendMutationAsync<VinculoVagaRegraDistribuicao>(
                "delete_vinculo_vaga_regra_distribuicao", new {item.IdVaga, item.IdRegraDistribuicao}.ToGraphString(), "id_vaga id_regra_distribuicao");

            response.IdVaga.Should().Be(item.IdVaga);
            response.IdRegraDistribuicao.Should().Be(item.IdRegraDistribuicao);
        }

        [Theory]
        [ClassData(typeof(ListVinculoVagaRegraDistribuicaosData))]
        public async Task List_VinculoVagaRegraDistribuicaos(Action<ICollection<VinculoVagaRegraDistribuicaoReadModel>, VinculoVagaRegraDistribuicaoFixture> assert, string customFilter = default)
        {
            var response = await SendQueryAsync<VinculoVagaRegraDistribuicaoListItemGraphType, VinculoVagaRegraDistribuicaoReadModel>(
                "list_vinculo_vagas_regras_distribuicao", 1, 20, customFilter);

            assert(response, Fixture);
        }

        [Fact]
        public async Task Update_RegistraCompensacao()
        {
            var vinculoVagaRegra = VinculoVagaRegraDistribuicaoFixture.VinculoRegistraCompensacao;
            var item = new
            {
                vinculoVagaRegra.IdRegraDistribuicao,
                Motivo = "Teste",
                Vagas = new[] { new { Id = vinculoVagaRegra.IdVaga, Compensacao = 0 } }
            };
            var response = await SendMutationAsync<CompensacaoInputType,  CompensacaoGraphType,
                Compensacao>("registra_compensacao", item);
            
            response.IdRegraDistribuicao.Should().Be(item.IdRegraDistribuicao);
            response.Motivo.Should().Be(item.Motivo);
        }
        
        [Theory]
        [ClassData(typeof(RegistraCompensacaoInvalidData))]
        public async Task Update_RegistraCompensacao_Invalida(object item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CompensacaoInputType, CompensacaoGraphType, Compensacao>(
                    "registra_compensacao", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Update_Vaga_Igualar_Distribuicao()
        {
            var idRegra = VinculoVagaRegraDistribuicaoFixture.RegraIgualarDistribuicao.Id;
            var vaga1 = VinculoVagaRegraDistribuicaoFixture.VagaIgualarDistribuicao1;
            var vaga2 = VinculoVagaRegraDistribuicaoFixture.VagaIgualarDistribuicao2;

            await SendMutationAsync<IgualarDistribuicaoInputType, CompensacaoGraphType,
                Compensacao>("igualar_distribuicao", new {IdRegraDistribuicao = idRegra, Motivo = "Teste"});

            var filter = $"id_regra_distribuicao: {idRegra}";
            var response = await SendQueryAsync<VinculoVagaRegraDistribuicaoListItemGraphType, VinculoVagaRegraDistribuicaoReadModel>(
                "list_vinculo_vagas_regras_distribuicao", 1, 20, filter);

            var vagaReadModel = response.Select(x => x.Vaga).First(x => x.Id == vaga2.Id);
            vagaReadModel.Compensacao.Equals(Math.Abs(vaga1.Distribuicoes - vaga2.Distribuicoes))
                .Should().BeTrue();
        }
        
        [Fact]
        public async Task Update_Vaga_Igualar_Distribuicao_Sem_Motivo()
        {
            var idRegra = VinculoVagaRegraDistribuicaoFixture.RegraIgualarDistribuicao.Id;

            await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<IgualarDistribuicaoInputType, CompensacaoGraphType,
                    Compensacao>("igualar_distribuicao", new {IdRegraDistribuicao = idRegra}));
        }
        
        [Fact]
        public async Task Update_Vaga_Igualar_Distribuicao_Sem_IdRegra()
        {
            await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<IgualarDistribuicaoInputType, CompensacaoGraphType,
                    Compensacao>("igualar_distribuicao", new {Motivo = "Teste"}));
        }
        
        [Fact]
        public async Task Update_Vaga_Igualar_Distribuicao_Motivo_Vazio()
        {
            var idRegra = VinculoVagaRegraDistribuicaoFixture.RegraIgualarDistribuicao.Id;
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<IgualarDistribuicaoInputType, CompensacaoGraphType,
                    Compensacao>("igualar_distribuicao", new {IdRegraDistribuicao = idRegra, Motivo = ""}));
            
            exception.Message.Should().Contain(DomainResources.MotivoIncorreto);
        }
        
        [Theory]
        [ClassData(typeof(ListHistoricoCompensacaoData))]
        public async Task List_CompensacaoLog(Action<ICollection<HistoricoCompensacaoRegraReadModel>, VinculoVagaRegraDistribuicaoFixture> assert, string customFilter = default)
        {
            var response = await SendQueryAsync<HistoricoCompensacaoRegraListGraphType, HistoricoCompensacaoRegraReadModel>(
                "list_historico_compensacao_regras_distribuicao", 1, 20, customFilter);

            assert(response, Fixture);
        }

        [Fact]
        public async Task List_Vinculo_Vaga_Regra_Ordenado_Por_Distribuicoes()
        {
            var regra = RegraDistribuicaoFaker.Entidade.Generate();
            var responseRegra = await SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                "create_regra_distribuicao", regra);
            
            var vagas = VagaFaker.Entidade.Generate(5);

            foreach (var vaga in vagas)
            {
                vaga.Distribuicoes += 1;
                var responseVaga = await SendMutationAsync<CreateVagaInputType, VagaGraphType, Vaga>("create_vaga", vaga);
                var vinculo = new VinculoVagaRegraDistribuicao
                {
                    IdRegraDistribuicao = responseRegra.Id,
                    IdVaga = responseVaga.Id
                };
                await SendMutationAsync<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType, VinculoVagaRegraDistribuicao>(
                    "create_vinculo_vaga_regra_distribuicao", vinculo);
            }
            
            var query = @"query{
                          list_vinculo_vagas_regras_distribuicao(
                            filter:{id_regra_distribuicao: #idRegra#}, 
                            sort:{field: ""vaga.distribuicoes""}
                          ){items{vaga{id distribuicoes}}}}".Replace("#idRegra#", responseRegra.Id.ToString());

            var send = await SendAsync(query);
            var list = await TestGraphQLParser.GetList<VinculoVagaRegraDistribuicaoReadModel>(send.Item1, "list_vinculo_vagas_regras_distribuicao");
            var response = list.Items;

            response.Should()
                .BeInAscendingOrder(x => x.Vaga.Distribuicoes);
        }
    }
}