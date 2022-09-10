using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoAreaExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarAreaJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Area != Area.Indefinida
                ? BuscaRegraComAreaJaCadastrada(regrasCadastradas, regraInformada)
                : BuscaRegraSemAreaCadastrada(regrasCadastradas);

        private static IQueryable<RegraDistribuicao> BuscaRegraSemAreaCadastrada(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where regraCadastrada.Area == Area.Indefinida
                select regraCadastrada;
        
        private static IQueryable<RegraDistribuicao> BuscaRegraComAreaJaCadastrada(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                where regraInformada.Area == regraCadastrada.Area
                select regraCadastrada;
    }
}