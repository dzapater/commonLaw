using System;
using System.Collections.Generic;
using Softplan.Common.MessageBus.Messages.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Events
{
    public class DistribuirProcessoResponse : ResponseMessage, IEventMessage
    {
        public string IdProcesso { get; set; }
        
        public Guid TransactionId { get; set; }
        public Vaga Vaga { get; set; }
        public RegraDistribuicao RegraDistribuicao { get; set; }
    }
}