using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoClasseExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarRegraClasseJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Classes.Any()
                ? BuscaRegraComClassesJaCadastradas(regrasCadastradas, regraInformada)
                : BuscaRegraSemClassesCadastrada(regrasCadastradas);
        
        private static IQueryable<RegraDistribuicao> BuscaRegraSemClassesCadastrada(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.Classes.Any()
                select regraCadastrada;
        
        private static IQueryable<RegraDistribuicao> BuscaRegraComClassesJaCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from classe in regraCadastrada.Classes
                where regraInformada.Classes.Select(ai => ai.IdClasse).Contains(classe.IdClasse)
                select regraCadastrada;
    }
}