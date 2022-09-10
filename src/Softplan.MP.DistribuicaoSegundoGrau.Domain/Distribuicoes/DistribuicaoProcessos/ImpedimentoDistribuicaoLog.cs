using System;
using System.IO;
using Google.Protobuf;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public class ImpedimentoDistribuicaoLog : IdImpedimentoDistribuicaoLog, IDomainModel
    {
        public static ImpedimentoDistribuicaoLog Create(DistribuirProcessoRequest command, IMessage domainEvent)
            => new ImpedimentoDistribuicaoLog(command, domainEvent);
        protected ImpedimentoDistribuicaoLog(DistribuirProcessoRequest command, IMessage domainEvent)
        {
            IdProcesso = command.IdProcesso;
            TransactionId = command.TransactionId;
            TipoDistribuicao = command.TipoDistribuicao;
            SerializeDomainEvent(domainEvent);            
        }

        protected ImpedimentoDistribuicaoLog()
        {
        }
        
        public string IdProcesso { get; protected set; }

        public Guid TransactionId { get; protected set; }
        
        public TipoDistribuicao TipoDistribuicao { get; set; }

        public string PayloadType { get; private set; }

        public PayloadSerializationType PayloadSerialization { get; private set; }

        public byte[] Payload { get; private set; }
        
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;

        private void SerializeDomainEvent(IMessage domainEvent)
        {
            PayloadType = domainEvent.GetType().FullName;
            PayloadSerialization = PayloadSerializationType.Protobuf;
            using (var stream = new MemoryStream())
            {
                domainEvent.WriteTo(stream);
                Payload = stream.ToArray();
            }
        }

        public enum PayloadSerializationType
        {
            Protobuf
        }
    }
}