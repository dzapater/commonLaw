using System.Threading.Tasks;
using FluentAssertions;
using Softplan.Common.Test.AspNetCore.GraphQL;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Permissoes;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Permissoes.Types;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Permissoes
{
    public class PermissaoSchemaExtensionTest : GraphTestBase<PermissaoFixture>, IClassFixture<PermissaoFixture>
    {
        public PermissaoSchemaExtensionTest(PermissaoFixture fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData(Claims.DSG_VAGA_CRIAR)]
        [InlineData(Claims.DSG_VAGA_OBTER, Claims.DSG_VAGA_LISTAR)]
        [InlineData(Claims.DSG_VAGA_LISTAR, Claims.DSG_REGRADISTIBUICAO_LISTAR)]
        [InlineData(Claims.DSG_REGRADISTIBUICAO_CRIAR, Claims.DSG_REGRADISTIBUICAO_OBTER, Claims.DSG_REGRADISTIBUICAO_ATUALIZAR, Claims.DSG_REGRADISTIBUICAO_DELETAR)]
        public async Task Get_Permissions(params string[] claims)
        {
            var filter = new PermissoesFiltro
            {
                Universo = claims
            };
            var result = await SendQueryAsync<PermissoesGraphType, Domain.Permissoes.Permissoes>("permissoes", filter);
            result.Should().NotBeNull();
            result?.Items.Should().BeEquivalentTo(claims);
        }
    }
}