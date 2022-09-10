using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaMotivo
    {
        public VinculoMembroVaga Vinculo { get; set; }
        public ICollection<MotivoMembroVagaReadModel> Motivos { get; set; }
    }
}