using System.Linq;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions
{
    public static class RegraDistribuicaoAssuntoExtensionFilterBuilder
    {
        public static IQueryable<RegraDistribuicao> FiltrarRegraAssuntoJaCadastrado(this IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
        => regraInformada.Assuntos.Any()
                ? BuscaRegraComAssuntosJaCadastrados(regrasCadastradas, regraInformada) 
                : BuscaRegraSemAssuntosCadastrados(regrasCadastradas);
        

        private static IQueryable<RegraDistribuicao> BuscaRegraSemAssuntosCadastrados(IQueryable<RegraDistribuicao> regrasCadastradas)
        => from regraCadastrada in regrasCadastradas
                where !regraCadastrada.Assuntos.Any()
                select regraCadastrada;

        private static IQueryable<RegraDistribuicao> BuscaRegraComAssuntosJaCadastrados(IQueryable<RegraDistribuicao> regrasCadastradas, RegraDistribuicao regraInformada)
        => from regraCadastrada in regrasCadastradas
                from assunto in regraCadastrada.Assuntos
                where regraInformada.Assuntos.Select(x => x.IdAssunto).Contains(assunto.IdAssunto)
                select regraCadastrada;
    }
}