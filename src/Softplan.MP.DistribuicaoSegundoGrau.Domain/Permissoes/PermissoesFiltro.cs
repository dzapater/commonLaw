using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Permissoes
{
    public class PermissoesFiltro
    {
        public IEnumerable<string> Universo { get; set; } = new string[] { };
    }
}