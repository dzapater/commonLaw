using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents
{
    public class ProcessoDocument
    {        
        public string Status { get; set; }
        public Area Area { get; set; }
        public int Volumes { get; set; }
        public long? IdAssunto { get; set; }
        public long? IdClasse { get; set; }
        public long? IdEspecialidade { get; set; }
        public int? IdOrgaoJulgador { get; set; }
        public int? IdOrigem { get; set; }
        public long? IdUnidade { get; set; }
        public IEnumerable<decimal> IdTarja { get; set; } = new List<decimal>();
    }
}