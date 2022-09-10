using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Processos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoFormatado : AnaliseProcesso
    {
        public Processo Processo => new Processo { Id = IdProcesso };
    }
}