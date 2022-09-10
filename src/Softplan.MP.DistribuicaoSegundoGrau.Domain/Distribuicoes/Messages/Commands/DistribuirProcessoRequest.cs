using System;
using System.Collections.Generic;
using Softplan.Common.MessageBus.Messages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands
{
    public class DistribuirProcessoRequest : ICommandMessage
    {
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public string IdProcesso { get; set; }
        public TipoDistribuicao TipoDistribuicao { get; set; }
        public int Volumes { get; set; }
        public int? IdVaga { get; set; }
        public int? IdRegraDistribuicao { get; set; }
        public string Motivo { get; set; }
        public int? CodigoForoDestino { get; set; }
        public int? CodigoLocalDestino { get; set; }
        public int? CodigoTipoLocalDestino { get; set; }
        public Area AreaProcesso { get; set; }
        public ProcessoDocument Processo { get; set; }
        public ICollection<ImpedimentoDistribuicaoLog> Logs { get; set; } = new List<ImpedimentoDistribuicaoLog>();
    }
}