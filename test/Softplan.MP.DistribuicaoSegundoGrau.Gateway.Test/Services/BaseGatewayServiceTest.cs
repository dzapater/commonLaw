using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.Graph.Client.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.Test.Services
{
    public class BaseGatewayServiceTest
    {
        
        private Mock<IGraphClientFactory> _moqGraphClientFactory = new Mock<IGraphClientFactory>();
        private Mock<IGraphClient> _moqGraphClient = new Mock<IGraphClient>();
        private Mock<IServiceProvider> _moqServiceProvider = new Mock<IServiceProvider>();
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryProcessos_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<ConsultaProcessoResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<ConsultaProcessoResponseMessage>()
                {
                    Value = new ConsultaProcessoResponseMessage()
                    {
                        Id = "testeProcesso"
                    }
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            var sut = new McdGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetProcessoById("teste");
            sut.Dispose();
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryEspecialidade_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<EspecialidadeResponseMessage>>(It.IsAny<string>(),
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<EspecialidadeResponseMessage>()
                {
                    Value = new EspecialidadeResponseMessage()
                    {
                        Id = 1
                    }
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            var sut = new McdGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetEspecialidadeById(1);
            sut.Dispose();
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryAreaAtuacao_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<AreaAtuacao>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<AreaAtuacao>()
                {
                    Value = new AreaAtuacao()
                    {
                        Id = 1,
                        Nome = "NomeTeste"
                    }
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            var sut = new McdGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetAreaAtuacaoById(1);
            sut.Dispose();
            response.Should().NotBeNull();
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryIdOrigem_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<OrigemResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<OrigemResponseMessage>()
                {
                    Value = new OrigemResponseMessage() {Id = 2}
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);
            

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);

            var sut = new PtcGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetOrigemById(1);
            sut.Dispose();
            response.Id.Should().Be(2);
        }
        
                [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryAssuntos_Entao_Retorno_EhSatisfeito()
        {
            
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<ItemsResponseMessage<AssuntoResponseMessage>>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<ItemsResponseMessage<AssuntoResponseMessage>>()
                {
                    Value = new ItemsResponseMessage<AssuntoResponseMessage>()
                    {
                        Items = new List<AssuntoResponseMessage>()
                        {
                            new AssuntoResponseMessage()
                            {
                                Descricao = "DescricaoTeste",
                                Id = 1
                            }
                        }
                    }
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            var sut = new TaxGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetAssuntosByIds(1);
            sut.Dispose();
            response.Should().NotBeEmpty();
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryClasses_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<ClasseResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<ClasseResponseMessage>()
                {
                    Value = new ClasseResponseMessage()
                    {
                        Descricao = "DescricaoTeste",
                        Id = 1}
                }));
            
            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            
            var sut = new TaxGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetClasseById(1);
            sut.Dispose();
            response.Id.Should().Be(1);
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryTarja_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<TarjaResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<TarjaResponseMessage>()
                {
                    Value = new TarjaResponseMessage()
                    {
                        Descricao = "DescricaoTarja",
                        Id = 10}
                }));
            
            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            
            var sut = new TaxGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetTarjaById(10);
            sut.Dispose();
            response.Id.Should().Be(10);
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryOrgaoJulgador_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<OrgaoJulgadorResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<OrgaoJulgadorResponseMessage>()
                {
                    Value = new OrgaoJulgadorResponseMessage()
                    {
                        Descricao = "DescricaoTeste",
                        Id = 1}
                }));
            
            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            
            var sut = new TaxGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetOrgaoJulgadorById("1",1,1);
            sut.Dispose();
            response.Id.Should().Be(1);
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryUnidade_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<UnidadeResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<UnidadeResponseMessage>()
                {
                    Value = new UnidadeResponseMessage()
                    {
                        Descricao = "DescricaoTeste"
                    }
                }));
            
            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);
            
            var sut = new TaxGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetUnidadeById("1",1);
            sut.Dispose();
            response.Descricao.Should().NotBeEmpty();
        }
        
        [Fact]
        public async void Dado_UmaRequisicaoValida_Quando_ChamaQueryIdLotacao_Entao_Retorno_EhSatisfeito()
        {
            _moqGraphClient.Setup(x =>
                    x.SendAsync<ResponseGatewayMessage<LotacaoResponseMessage>>(It.IsAny<string>(), 
                        It.IsAny<object>()
                        , default))
                .Returns(Task.FromResult( new ResponseGatewayMessage<LotacaoResponseMessage>()
                {
                    Value = new LotacaoResponseMessage() {IdLocal = 20}
                }));

            _moqGraphClientFactory.Setup(x => x.GetGraphClient("APOLLO")).Returns(_moqGraphClient.Object);
            

            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClientFactory))).Returns(_moqGraphClientFactory.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IGraphClient))).Returns(_moqGraphClient.Object);

            var sut = new UsrGatewayService(_moqServiceProvider.Object);
            var response = await sut.GetIdLocalByLotacaoId(1, "usuarioTeste");
            sut.Dispose();
            response.IdLocal.Should().Be(20);
        }
    }
}