using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoTarjaExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarRegraTarjaJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Tarjas.Any()
                ? BuscaRegraComTarjasJaCadastradas(regrasCadastradas, regraInformada)
                : BuscaRegraSemTarjasCadastradas(regrasCadastradas);

        private static IQueryable<RegraDistribuicao> BuscaRegraSemTarjasCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.Tarjas.Any()
                select regraCadastrada;

        private static IQueryable<RegraDistribuicao> BuscaRegraComTarjasJaCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from tarja in regraCadastrada.Tarjas
                where regraInformada.Tarjas.Select(ai => ai.IdTarja).Contains(tarja.IdTarja)
                select regraCadastrada;
    }
}