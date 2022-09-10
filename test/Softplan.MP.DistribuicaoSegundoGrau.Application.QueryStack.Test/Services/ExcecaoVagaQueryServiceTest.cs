using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Fakers;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Services
{
    public class ExcecaoVagaQueryServiceTest
    {
        [Fact]
        public async void Dado_ExcecaoVaga_Quando_ChamaQuery_Entao_RetornoListaExcecao_EhSatisfeito()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Section", "ValueSection"},
                {"SectionName:SomeKey", "SectionValue"},
                
            };
            
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            
            var _moqServiceProvider = new Mock<IServiceProvider>();
            var _moqDbContext = new Mock<QueryDbContext>(_moqServiceProvider.Object,configuration);

            _moqDbContext.Setup(x => x.Set<ExcecaoVaga>())
                .Returns(new FakeDbSet<ExcecaoVaga>
                {
                    new ExcecaoVaga { IdVaga = 1 }
                });
            
            var sut = new ExcecaoVagaQueryService(_moqDbContext.Object);
            var arrange = new ExcecaoVagaFilter() {IdVaga = 1};
            sut.ListAsync(arrange, new List<Sort>());

            sut.Should().NotBeOfType<Exception>();
        }
    }
}