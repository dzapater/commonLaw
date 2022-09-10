using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoEspecialidadeExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarEspecialidadeJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Especialidades.Any()
                ? BuscaRegraComEspecialidadesJaCadastradas(regrasCadastradas, regraInformada)
                : BuscaRegraSemEspecialidadesCadastradas(regrasCadastradas);

        private static IQueryable<RegraDistribuicao> BuscaRegraSemEspecialidadesCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.Especialidades.Any()
                select regraCadastrada;
        
        private static IQueryable<RegraDistribuicao> BuscaRegraComEspecialidadesJaCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from especialidade in regraCadastrada.Especialidades
                where regraInformada.Especialidades.Select(x => x.IdEspecialidade).Contains(especialidade.IdEspecialidade)
                select regraCadastrada;
    }
}