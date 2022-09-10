using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Fakers;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Test.Services
{
    public class DistribuicaoProcessoQueryServiceTest
    {
        [Fact]
        public async void Dado_Distribuicao_Quando_ChamaQuery_Entao_RetornoDistribuicao_EhSatisfeito()
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
            var distribuicaoProcesso = DistribuicaoProcessoReadModelFaker.RequestCriarDistribuicaoProcesso.Generate();
                
            _moqDbContext.Setup(x => x.Set<DistribuicaoProcesso>())
                .Returns(new FakeDbSet<DistribuicaoProcesso>
                {
                    distribuicaoProcesso.DistribuicaoProcesso
                });
            
            _moqDbContext.Setup(x => x.Set<DistribuicaoProcessoLog>())
                .Returns(new FakeDbSet<DistribuicaoProcessoLog>
                {
                    distribuicaoProcesso.DistribuicaoProcessoLog.FirstOrDefault()
                });
            
            _moqDbContext.Setup(x => x.Set<DistribuicaoProcessoReadModel>())
                .Returns(new FakeDbSet<DistribuicaoProcessoReadModel>
                {
                    distribuicaoProcesso
                });
            
            var sut = new DistribuicaoProcessoQueryService(_moqDbContext.Object);
            var arrange = new DistribuicaoProcessoFilter() {IdProcesso = distribuicaoProcesso.DistribuicaoProcesso.IdProcesso};
            await sut.GetDistribuicaoProcessoById(arrange);

            sut.Should().NotBeOfType<Exception>();
        }
    }
}