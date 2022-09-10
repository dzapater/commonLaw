using Softplan.Common.MessageBus.Messages.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands
{
    public class AgendarRemessaProcessoCommand : ICommandMessage
    {
        public string IdProcesso { get; set; }
        public int IdVaga { get; set; }
        public int CodigoForoDestino { get; set; }
        public int CodigoLocalDestino { get; set; }
        public int CodigoTipoLocalDestino { get; set; }
    }
}