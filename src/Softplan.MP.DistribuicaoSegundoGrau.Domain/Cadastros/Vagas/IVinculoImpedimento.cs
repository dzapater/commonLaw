using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public interface IVinculoImpedimento
    {
        public IEnumerable<ImpedimentoProcesso> ImpedimentoProcesso { get; set; }
    }
}