using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Cache.Redis.Interfaces
{
    public interface IContentCache
    {
        Task RemoveCacheContentAsync(string key);
        Task<string> GetContentFromCacheAsync(string key);
        Task SetContentFromCacheAsync(string key, string value);
    }
}