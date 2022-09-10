using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Softplan.Common.Cache.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis.Interfaces;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Constantes;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis
{
    public class ContentCache: IContentCache
    {
        private readonly ISoftplanDistributedCache _distributedCache;
        private readonly TimeSpan _cacheTimeSpan;

        public ContentCache(ISoftplanDistributedCache distributedCache, IOptions<CacheTimeRedisConfiguration> options)
        {
            _distributedCache = distributedCache;
            _cacheTimeSpan = TimeSpan.FromSeconds(options.Value.CacheRedisTimeoutSeconds);
        }
        
        public async Task RemoveCacheContentAsync(string key)
        {
            await _distributedCache.RemoveAsync(key, builder => { });
        }
        public async Task<string> GetContentFromCacheAsync(string key)
        {
            return await _distributedCache.GetValueAsync<string>(key, builder => { });
        }
        
        public async Task SetContentFromCacheAsync(string key, string value)
        {
            await _distributedCache.SetValueAsync(key, value, _cacheTimeSpan, builder => { });
        }

    }
}