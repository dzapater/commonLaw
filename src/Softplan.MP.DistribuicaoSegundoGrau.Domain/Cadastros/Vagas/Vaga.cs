using System.Collections.Generic;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class Vaga : IdVaga, IDomainModel, IVinculoImpedimento
    {
        public Orgao Orgao { get; set; }
        public int IdInstalacao { get; set; }
        public ProcuradorTitular ProcuradorTitular { get; set; }
        public string Descricao { get; set; }
        public Area Area { get; set; } = default;
        public bool EstaAtiva { get; set; }
        public bool PermiteReuPreso { get; set; }
        public bool PermiteDistribuicaoMesmaVaga { get; set; }
        public bool ConsiderarConfiguracoesPrevencao { get; set; }
        public int Distribuicoes { get; set; }
        public int Compensacao { get; set; }
        public string Motivo { get; set; }
        public int DistribuicaoPorVolume { get; set; }
        public int CompensacaoPorVolume { get; set; }        
        public int CdLocal { get; set; }
        public ICollection<IVinculoRegra> RegrasVinculadas { get; set; } = new List<IVinculoRegra>();
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public List<string> Mensagens { get; set; } = new List<string>();
        public IEnumerable<ImpedimentoProcesso> ImpedimentoProcesso { get; set; }
    }
}