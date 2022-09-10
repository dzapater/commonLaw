using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class CompensacaoLog : IdCompensacaoLog, IDomainModel
    {
        public int IdVaga { get; set; }
        public string Motivo { get; set; }
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public Vaga Vaga { get; set; }
        public int Valor { get; set; }

        public CompensacaoLog()
        {
        }
        
        public CompensacaoLog(Vaga vagaCadastrada, Vaga vagaCompensada)
        {
            IdVaga = vagaCadastrada.Id;
            Motivo = vagaCompensada.Motivo;
            Valor = vagaCompensada.Compensacao - vagaCadastrada.Compensacao;
        }
    }
}