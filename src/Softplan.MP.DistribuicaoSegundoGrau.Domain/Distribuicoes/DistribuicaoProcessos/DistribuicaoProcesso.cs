using System.Collections.Generic;
using Google.Protobuf;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcesso : SimpleId<long>, IDomainModel
    {
        public static DistribuicaoProcesso Create(LogarDistribuicaoProcessoCommand command)
            => new DistribuicaoProcesso(command) { };

        private DistribuicaoProcesso(LogarDistribuicaoProcessoCommand command)
        {
            IdProcesso = command.IdProcesso;
            Metadata = new EntityMetadata
            {
                Uuid = command.TransactionId
            };
            Motivo = command.Motivo;
            TipoDistribuicao = command.TipoDistribuicao;
            IdVaga = command.IdVaga;
        }

        private DistribuicaoProcesso()
        {
        }

        private readonly HashSet<DistribuicaoProcessoLog> _logs = new HashSet<DistribuicaoProcessoLog>();

        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;

        public string IdProcesso { get; private set; }
        public int? IdVaga { get; private set; }
        public string Motivo { get; private set; }
        public TipoDistribuicao TipoDistribuicao { get; private set; }
        public IReadOnlyCollection<DistribuicaoProcessoLog> Logs => _logs;

        public void AddLog(IMessage domainEvent)
            => _logs.Add(DistribuicaoProcessoLog.Create(this, domainEvent));

    }
}