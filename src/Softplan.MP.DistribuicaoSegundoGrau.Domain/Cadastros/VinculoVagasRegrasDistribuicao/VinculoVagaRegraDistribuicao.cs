using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicao : IdVinculoVagaRegraDistribuicao, IDomainModel, IVinculoVaga, IVinculoRegra
    {
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public Vaga Vaga { get; set; }
        public RegraDistribuicao RegraDistribuicao { get; set; }
        public int DistribuicaoPorVolume { get; set; }
        public int CompensacaoPorVolume { get; set; }
        public int DistribuicaoPorProcesso { get; set; }
        public int CompensacaoPorProcesso { get; set; }
    }
}