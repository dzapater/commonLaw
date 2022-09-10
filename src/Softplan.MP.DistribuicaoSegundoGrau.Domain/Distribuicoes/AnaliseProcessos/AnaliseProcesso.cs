using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcesso : IdAnaliseProcesso, IDomainModel
    {
        public int? IdVaga { get; set; }
        public string Motivo { get; set; }
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public TipoDistribuicao TipoDistribuicao { get; set; } = TipoDistribuicao.Indefinida;
        public AreaAtuacao AreaAtuacao { get; set; }
    }
}