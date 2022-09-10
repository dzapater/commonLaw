using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Exceptions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Test.Providers
{
    public class LotacaoUsuarioLogadoProviderTests
    {

        private (Mock<IHttpContextAccessor>, LotacaoUsuarioLogadoProvider) CriarProvider(string lotacaoId)
        {
            var moq = new Mock<IHttpContextAccessor>();
            moq.Setup(x => x.HttpContext.Request.Headers["lotacao"]).Returns(lotacaoId);
            moq.Setup(x => x.HttpContext.Response.Headers["lotacao"]);

            return (moq, new LotacaoUsuarioLogadoProvider(moq.Object));
        }

        [Fact]
        public void Dado_HeaderLotacaoNaoEhNuloOuVazio_Quando_FazRequisicao_Entao_LotacaoIsNotEmpty()
        {
            var expectedLotacaoId = "2";
            (var _, var provider) = CriarProvider(expectedLotacaoId);
            LotacaoUsuarioLogado lotacaoId = provider.Get();
            lotacaoId.Equals(expectedLotacaoId).Should().BeTrue();
            lotacaoId.Equals(lotacaoId).Should().BeTrue();
            lotacaoId.Equals((object)lotacaoId).Should().BeTrue();
            lotacaoId.Equals("").Should().BeFalse();
            Assert.Equal(expectedLotacaoId, lotacaoId.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Dado_HeaderLotacaoEhNuloOuVazio_Quando_FazRequisicao_Entao_Excecao_EhSatisfeita(string strLotacaoId)
        {
            (var _, var provider) = CriarProvider(strLotacaoId);            
            Assert.Throws<UsuarioLotacaoNuloException>(() => provider.Get());
        }

    }
}
