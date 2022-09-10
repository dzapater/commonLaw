using Softplan.Common.Core.Entities;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Parametros
{
    public class Parametro : SimpleId<long>
    {
        public string Descricao { get; set; }
        public int Desvio { get; set; }

        public static string GetDescriptionValue(string name)
            => name switch
            {
                "Volume" => "FMP - Valor do Desvio para distribuição de processos volumosos",
                "Global" => "FMP - Valor do Desvio Global para distribuição",
                "Local" => "FMP - Valor do Desvio para distribuição",
                _ => default
            };
    }
}