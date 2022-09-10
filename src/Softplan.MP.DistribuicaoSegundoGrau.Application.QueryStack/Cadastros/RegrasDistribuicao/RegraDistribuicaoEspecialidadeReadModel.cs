using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoEspecialidadeReadModel
    {
        public RegraDistribuicao Regra { get; set; }
        public CriterioEspecialidade Especialidade { get; set; }
        public int QuantidadeVinculosAtivos { get; set; }
        public int QuantidadeVinculosTotal { get; set; }
    }
}