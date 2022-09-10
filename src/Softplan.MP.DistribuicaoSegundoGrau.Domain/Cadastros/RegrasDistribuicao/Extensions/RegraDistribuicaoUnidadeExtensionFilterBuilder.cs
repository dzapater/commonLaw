using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoUnidadeExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarRegraUnidadeJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Unidades.Any()
                ? BuscaRegraComUnidadesJaCadastradas(regrasCadastradas, regraInformada)
                : BuscaRegraSemUnidadesCadastradas(regrasCadastradas);

        private static IQueryable<RegraDistribuicao> BuscaRegraSemUnidadesCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.Unidades.Any()
                select regraCadastrada;

        private static IQueryable<RegraDistribuicao> BuscaRegraComUnidadesJaCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from unidade in regraCadastrada.Unidades
                where regraInformada.Unidades.Select(x => x.IdUnidade).Contains(unidade.IdUnidade)
                where regraInformada.Unidades.Select(x => x.IdOrigem).Contains(unidade.IdOrigem)
                select regraCadastrada;
        
    }
}