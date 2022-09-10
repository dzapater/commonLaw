using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.VinculoMembroVagas.Types;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas
{
    public class MotivoMembroVagaSchemaExtensionTest : GraphTestBase<MotivoMembroVagaFixture>,
        IClassFixture<MotivoMembroVagaFixture>
    {
        public MotivoMembroVagaSchemaExtensionTest(MotivoMembroVagaFixture fixture) : base(fixture)
        {
        }
        
        [Theory]
        [ClassData(typeof(ListMotivoMembroVagasData))]
        public async Task List_MotivoMembroVagas(Action<ICollection<MotivoMembroVagaReadModel>, MotivoMembroVagaFixture> assert, string customFilter = default )
        {
            var response = await SendQueryAsync<MotivoMembroVagaListItemGraphType, MotivoMembroVagaReadModel>(
                "list_motivo_membro_vaga", 1, 20, customFilter);

            assert(response, Fixture);
        }
    }
}