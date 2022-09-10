using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class Compensacao
    {
        public int IdRegraDistribuicao { get; set; }
        public string Motivo { get; set; }
        public ICollection<Vaga> Vagas { get; set; }
    }
}