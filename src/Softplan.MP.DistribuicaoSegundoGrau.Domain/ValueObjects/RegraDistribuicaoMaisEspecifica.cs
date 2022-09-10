using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.ValueObjects
{
    public class RegraDistribuicaoMaisEspecifica
    {
        public RegraDistribuicaoMaisEspecifica(List<RegraDistribuicao> regraDistribuicao, ProcessoDocument processo)
        {
            regraDistribuicao.ForEach(regra => ValidaCriteriosDaRegra(regra, processo));
            RegraMaisEspecifica = RetornaRegraMaisEspecifica();
        }

        private static int _contadorDeCriterios;
        private static readonly IDictionary<RegraDistribuicao, int> RegraEspecifica = new Dictionary<RegraDistribuicao, int>();
        public readonly IOrderedEnumerable<KeyValuePair<RegraDistribuicao, int>> RegraMaisEspecifica;

        private static void ValidaCriteriosDaRegra(RegraDistribuicao regraDistribuicao, ProcessoDocument processo)
        {
            ContemEspecialidade(in regraDistribuicao, processo.IdEspecialidade);
            ContemAssunto(in regraDistribuicao, processo.IdAssunto);
            ContemClasse(in regraDistribuicao, processo.IdClasse);
            if (processo.IdTarja.Any())
                foreach (var idTarja in processo.IdTarja)
                    ContemTarja(in regraDistribuicao, idTarja);
            ContemUnidade(in regraDistribuicao, processo.IdUnidade);
            ContemOrgaoJulgador(in regraDistribuicao, processo.IdOrgaoJulgador);
            
            RegraEspecifica.Add(regraDistribuicao,_contadorDeCriterios);
            _contadorDeCriterios = 0;
        }

        private static void ContemEspecialidade(in RegraDistribuicao regraDistribuicao, long? idEspecialidade)
        {
            if (regraDistribuicao != null && regraDistribuicao.Especialidades.Any(x => x.IdEspecialidade == idEspecialidade))
                _contadorDeCriterios += 1;
        }

        private static void ContemAssunto(in RegraDistribuicao regraDistribuicao, long? idAssunto)
        {
            if (regraDistribuicao != null && regraDistribuicao.Assuntos.Any(x => x.IdAssunto == idAssunto))
                _contadorDeCriterios += 1;
        }

        private static void ContemClasse(in RegraDistribuicao regraDistribuicao, long? idClasse)
        {
            if (regraDistribuicao != null && regraDistribuicao.Classes.Any(x => x.IdClasse == idClasse))
                _contadorDeCriterios += 1;
        }

        private static void ContemTarja(in RegraDistribuicao regraDistribuicao, decimal? idTarja)
        {
            if (regraDistribuicao != null && regraDistribuicao.Tarjas.Any(x => x.IdTarja == idTarja)) 
                _contadorDeCriterios += 1;
        }

        private static void ContemUnidade(in RegraDistribuicao regraDistribuicao, long? idUnidade)
        {
            if(regraDistribuicao != null && regraDistribuicao.Unidades.Any(x => x.IdUnidade == idUnidade))
                _contadorDeCriterios += 1;
        }

        private static void ContemOrgaoJulgador(in RegraDistribuicao regraDistribuicao, int? idOrgaoJulgador)
        {
            if (regraDistribuicao != null && regraDistribuicao.OrgaosJulgadores.Any(x => x.IdOrgaoJulgador == idOrgaoJulgador))
                _contadorDeCriterios += 1;
        }

        private static IOrderedEnumerable<KeyValuePair<RegraDistribuicao, int>> RetornaRegraMaisEspecifica()=>
            RegraEspecifica.OrderByDescending(x => x.Value);
    }
}