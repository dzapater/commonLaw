using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.DistributedLock.Abstractions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions;
using Softplan.Common.MessageBus.Abstractions.DistributedTransactions.Contexts;
using Softplan.Common.MessageBus.Abstractions.Producers;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.Common.Test.AspNetCore.GraphQL.Extensions;
using Softplan.Common.Test.Core.EquivalencyRules;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoVagasRegrasDistribuicao.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao.Scenarios;
using Xunit;
using Xunit.Sdk;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoSchemaExtensionTest : GraphTestBase<RegraDistribuicaoFixture>,
        IClassFixture<RegraDistribuicaoFixture>
    {
        public RegraDistribuicaoSchemaExtensionTest(RegraDistribuicaoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Create_Regra_Distribuicao()
        {
            var item = RegraDistribuicaoFaker.Entidade.Generate();

            item.Area = Area.Ambas;

            var response = await SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                "create_regra_distribuicao", item);

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.Id)
                    .Excluding(x => x.Metadata)
                    .Excluding(x => x.CdLocal)
                    .Excluding(x => x.Especialidades), response, item);
        }

        [Theory]
        [ClassData(typeof(CreateRegraDistribuicaoInvalidaData))]
        public async Task Create_Regra_Distribuicao_Invalida(RegraDistribuicao item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                    "create_regra_distribuicao", item));

            exception.Message.Should().Contain(containsMessage);
        }

        [Fact]
        public async Task Delete_Regra_Distribuicao()
        {
            var item = RegraDistribuicaoFixture.RegraRemovida;

            var response = await SendMutationAsync<RegraDistribuicao>(
                "delete_regra_distribuicao", new {id = item.Id}.ToGraphString(), "id");

            response.Id.Should().Be(item.Id);
        }

        [Theory]
        [ClassData(typeof(DeleteRegraDistribuicaoInvalidaData))]
        public async Task Delete_Regra_Distribuicao_Invalida(RegraDistribuicao item, string containsMessage)
        {
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<RegraDistribuicao>(
                    "delete_regra_distribuicao", new {id = item.Id}.ToGraphString(), "id"));

            exception.Message.Should().Contain(containsMessage);
        }
        
        [Fact]
        public async Task Delete_Regra_Distribuicao_Quando_Regra_Vinculada()
        {
            var regra = RegraDistribuicaoFaker.Entidade.Generate();
            var regraResponse = await SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                "create_regra_distribuicao", regra);

            var vaga = VagaFaker.Entidade.Generate();
            var vagaResponse = await SendMutationAsync<CreateVagaInputType, VagaGraphType, Vaga>("create_vaga", vaga);

            var vinculo = new VinculoVagaRegraDistribuicao
                { IdVaga = vagaResponse.Id, IdRegraDistribuicao = regraResponse.Id };
            
            await SendMutationAsync<CreateVinculoVagaRegraDistribuicaoInputType, VinculoVagaRegraDistribuicaoGraphType, VinculoVagaRegraDistribuicao>(
                "create_vinculo_vaga_regra_distribuicao", vinculo);

            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<RegraDistribuicao>(
                    "delete_regra_distribuicao", new {id = regraResponse.Id}.ToGraphString(), "id"));

            exception.Message.Should().Contain(DomainResources.RegraUtilizadaNaDistribuicao);
        }

        [Fact]
        public async Task Get_Regra_Distribuicao()
        {
            var item = RegraDistribuicaoFixture.RegraCriada;

            var response = await SendQueryAsync<RegraDistribuicaoGraphType, RegraDistribuicao>(
                "regra_distribuicao", new {id = item.Id});

            AssertionHelper.BeEquivalentTo(config
                => config
                    .Excluding(x => x.CdLocal)
                    .Excluding(x => x.Metadata), response, item);
        }

        [Theory]
        [ClassData(typeof(ListRegrasDistribuicaoData))]
        public async Task List_Regras_Distribuicao(Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert, string customFilter = default)
        {
            var response = await SendQueryAsync<RegraDistribuicaoListItemGraphType, RegraDistribuicaoReadModel>(
                "list_regras_distribuicao", 1, 20, customFilter);

            assert(response, Fixture);
        }
        
        [Fact]
        public async Task Create_Regra_Quando_OrgaoJulgador_Invalido_Para_Unidade_Informada()
        {
            var item = RegraDistribuicaoFaker.Entidade.Generate();
            item.OrgaosJulgadores = new List<CriterioOrgaoJulgador>
                { new CriterioOrgaoJulgador { IdOrigem = 2, IdUnidade = default, IdOrgaoJulgador = default } };
            
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                    "create_regra_distribuicao", item));
            
            exception.Message.Should().Contain(DomainResources.OrgaoJulgadorInvalidoParaUnidadeInformada);
        }
        
        [Fact]
        public async Task Update_Regra_Quando_OrgaoJulgador_Invalido_Para_Unidade_Informada()
        {
            var item = RegraDistribuicaoFaker.Entidade.Generate();
            item.OrgaosJulgadores = new List<CriterioOrgaoJulgador>
                { new CriterioOrgaoJulgador { IdOrigem = 2, IdUnidade = 1, IdOrgaoJulgador = 1 } };
            var response = await SendMutationAsync<CreateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                "create_regra_distribuicao", item);
            
            response.OrgaosJulgadores = new List<CriterioOrgaoJulgador>
                { new CriterioOrgaoJulgador { IdOrigem = 2, IdUnidade = default, IdOrgaoJulgador = default } };
            
            var exception = await Assert.ThrowsAsync<XunitException>(()
                => SendMutationAsync<UpdateRegraDistribuicaoInputType, RegraDistribuicaoGraphType, RegraDistribuicao>(
                    "update_regra_distribuicao", response));
            
            exception.Message.Should().Contain(DomainResources.OrgaoJulgadorInvalidoParaUnidadeInformada);
        }
    }
}