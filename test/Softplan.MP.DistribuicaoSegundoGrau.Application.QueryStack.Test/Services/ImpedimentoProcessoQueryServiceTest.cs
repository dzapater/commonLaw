using System;
using System.Collections.Generic;
using Elastic.Apm.Api;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Softplan.Common.Core.Entities;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Impedimento;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Fakers;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Services
{
    public class ImpedimentoProcessoQueryServiceTest
    {

        [Fact]
        public async void Dado_Impedimento_Quando_ChamaQuery_Entao_RetornoListaImpedimento_EhSatisfeito()
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

            _moqDbContext.Setup(x => x.Set<ImpedimentoProcesso>())
                .Returns(new FakeDbSet<ImpedimentoProcesso>
                {
                    new ImpedimentoProcesso { IdProcesso = "xpto" }
                });
            
            var sut = new ImpedimentoProcessoQueryService(_moqDbContext.Object);
            var arrange = new ImpedimentoFilter() {IdProcesso = "xpto", IdVaga = 1};
            sut.ListAsync(arrange, new List<Sort>());

            sut.Should().NotBeOfType<Exception>();
        }
    }
}