using System.Collections.Generic;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcesso : IdImpedimentoProcesso, IDomainModel
    {
        public int IdVaga { get; set; }
        public string Motivo { get; set; }
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public Vaga Vaga { get; set; } 
        public List<string> Mensagens { get; set; } = new List<string>();
    }
}