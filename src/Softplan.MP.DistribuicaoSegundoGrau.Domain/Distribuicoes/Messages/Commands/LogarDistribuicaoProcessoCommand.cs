using System;
using System.Collections.Generic;
using Softplan.Common.MessageBus.Messages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands
{
    public class LogarDistribuicaoProcessoCommand : ICommandMessage
    {

        public Guid TransactionId { get; set; }
        public string IdProcesso { get; set; }
        public int Volumes { get; set; }
        public TipoDistribuicao TipoDistribuicao { get; set; }
        public Area AreaProcesso { get; set; }
        public int IdVaga { get; set; }
        public int? IdRegraDistribuicao { get; set; }
        public string Motivo { get; set; }
        public int CodigoForoDestino { get; set; }
        public int CodigoLocalDestino { get; set; }
        public int CodigoTipoLocalDestino { get; set; }
        public long IdLoteDistribuicao { get; set; }
    }
}