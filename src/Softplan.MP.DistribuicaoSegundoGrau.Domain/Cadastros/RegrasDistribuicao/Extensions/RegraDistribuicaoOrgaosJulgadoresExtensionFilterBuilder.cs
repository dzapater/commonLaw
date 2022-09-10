using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoOrgaosJulgadoresExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarRegraOrgaoJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.OrgaosJulgadores.Any()
                ? BuscaRegraComOrgaosJulgadoresJaCadastrados(regrasCadastradas, regraInformada)
                : BuscaRegraSemOrgaosJulgadoresCadastrados(regrasCadastradas);
        
        private static IQueryable<RegraDistribuicao> BuscaRegraSemOrgaosJulgadoresCadastrados(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.OrgaosJulgadores.Any()
                select regraCadastrada;

        private static IQueryable<RegraDistribuicao> BuscaRegraComOrgaosJulgadoresJaCadastrados(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from orgao in regraCadastrada.OrgaosJulgadores
                where regraInformada.OrgaosJulgadores.Select(ai => ai.IdOrgaoJulgador).Contains(orgao.IdOrgaoJulgador)
                where regraInformada.OrgaosJulgadores.Select(ai => ai.IdUnidade).Contains(orgao.IdUnidade)
                where regraInformada.OrgaosJulgadores.Select(ai => ai.IdOrigem).Contains(orgao.IdOrigem)
                select regraCadastrada;
        }
}