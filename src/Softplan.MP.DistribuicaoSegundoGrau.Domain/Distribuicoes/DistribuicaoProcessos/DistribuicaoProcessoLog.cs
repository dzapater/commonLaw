using System;
using System.IO;
using Google.Protobuf;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcessoLog : IdDistribuicaoProcessoLog
    {
        public static DistribuicaoProcessoLog Create(DistribuicaoProcesso distribuicaoProcesso, IMessage domainEvent)
            => new DistribuicaoProcessoLog(distribuicaoProcesso, domainEvent);
        
        public static DistribuicaoProcessoLog Create(DistribuirProcessoRequest command, IMessage domainEvent)
            => new DistribuicaoProcessoLog(command, domainEvent);

        protected DistribuicaoProcessoLog(DistribuicaoProcesso distribuicaoProcesso, IMessage domainEvent)
        {
            IdProcesso = distribuicaoProcesso.IdProcesso;
            TransactionId = distribuicaoProcesso.Metadata.Uuid;
            SerializeDomainEvent(domainEvent);            
        }
        
        protected DistribuicaoProcessoLog(DistribuirProcessoRequest command, IMessage domainEvent)
        {
            IdProcesso = command.IdProcesso;
            TransactionId = command.TransactionId;
            SerializeDomainEvent(domainEvent);            
        }

        protected DistribuicaoProcessoLog()
        {
        }
        
        public string IdProcesso { get; protected set; }

        public Guid TransactionId { get; protected set; }

        public string PayloadType { get; private set; }

        public long DistribuicaoId { get; private set; }

        public PayloadSerializationType PayloadSerialization { get; private set; }

        public byte[] Payload { get; private set; }

        public dynamic DomainEvent => Type.GetType(PayloadType)?.Name switch
        {
            nameof(ProcessoFoiDistribuidoPorPrevencao) => ProcessoFoiDistribuidoPorPrevencao.Parser.ParseFrom(Payload),
            nameof(VagasForamImpedidasParaDistribuicao) => VagasForamImpedidasParaDistribuicao.Parser.ParseFrom(Payload),
            nameof(VagaFoiSelecionadaParaDistribuicao) => VagaFoiSelecionadaParaDistribuicao.Parser.ParseFrom(Payload),
            nameof(RemessaProcessoFoiAgendada) => RemessaProcessoFoiAgendada.Parser.ParseFrom(Payload),
            nameof(ProcessoFoiDistribuidoPorSorteio) => ProcessoFoiDistribuidoPorSorteio.Parser.ParseFrom(Payload),
            nameof(ProcessoVagasRemovidasDistribuicaoMesmaVaga) => ProcessoVagasRemovidasDistribuicaoMesmaVaga.Parser.ParseFrom(Payload),
            _ => default
        };

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