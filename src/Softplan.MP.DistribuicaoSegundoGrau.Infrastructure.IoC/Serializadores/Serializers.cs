using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC.Serializadores
{
    public static class Serializers
    {
        public static string JsonSerialize<T>(T content)
        {
            return JsonSerializer.Serialize(content, JsonDefaultOptions);
        }

        public static Task<T> JsonDeserialize<T>(string content)
        {
            return Task.FromResult(JsonSerializer.Deserialize<T>(content, JsonDefaultOptions));
        }

        private static readonly JsonSerializerOptions JsonDefaultOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
}