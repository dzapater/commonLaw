using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Softplan.Common.Cache.Abstractions;
using Softplan.Common.Cache.Abstractions.Builder;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Constantes;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Test.Cache
{
    public class CacheTest
    {
        private Mock<ISoftplanDistributedCache> CacheCommons = new Mock<ISoftplanDistributedCache>();
        
        private readonly IOptions<CacheTimeRedisConfiguration> _options = Options.Create(new CacheTimeRedisConfiguration()
            {CacheRedisTimeoutSeconds = 30});
        private readonly ContentCache _contentCache;


        public CacheTest()
        {
            CacheCommons.Setup(x =>
                x.GetValueAsync<string>(It.IsAny<string>(), It.IsAny<Action<ICacheIsolationBuilder>>())).
                Returns(Task.FromResult<string>("GetContent"));
            
            CacheCommons.Setup(x =>
                    x.SetValueAsync<string>(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<TimeSpan>() ,It.IsAny<Action<ICacheIsolationBuilder>>())).
                Returns(Task.FromResult<string>("SetContent"));
            
            CacheCommons.Setup(x =>
                    x.RemoveAsync(It.IsAny<string>(), It.IsAny<Action<ICacheIsolationBuilder>>())).
                Returns(Task.FromResult<string>("RemoveContent"));

            _contentCache = new ContentCache(CacheCommons.Object, _options);
        }

        [Fact]
        public async Task Dado_Valor_Quando_BuscaValorCache_Entao_GetContent_EhStatisfeito()
        {
            var sut = await _contentCache.GetContentFromCacheAsync("GetContent");
            sut.Should().NotBeNull();
        }
        
        [Fact]
        public void Dado_ChaveValor_Quando_SetaChaveValorCache_Entao_SetContent_EhStatisfeito()
        {
            var sut = _contentCache.SetContentFromCacheAsync("SetContent", "SetContent");
            sut.Status.Should().Be(TaskStatus.RanToCompletion);
        }
        
        [Fact]
        public void Dado_Chave_Quando_RemoveCache_Entao_RemoveContent_EhStatisfeito()
        {
            var sut = _contentCache.RemoveCacheContentAsync("RemoveContent");
            sut.Status.Should().Be(TaskStatus.RanToCompletion);
        }
    }
}