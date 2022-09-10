using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Permissoes
{
    public class Permissoes
    {
        public string Usuario { get; set; }
        public int? Lotacao { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}