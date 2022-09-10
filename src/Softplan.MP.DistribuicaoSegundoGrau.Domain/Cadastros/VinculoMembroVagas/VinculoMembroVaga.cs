using System;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVaga : IdVinculoMembroVaga, IDomainModel
    {
        public int IdMotivoMembroVaga { get; set; }
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public Vaga Vaga { get; set; }
        public RegraDistribuicao RegraDistribuicao { get; set; }
        public string ProcuradorTitularId { get; set; }
        public string Observacao { get; set; } = "";

        public string IdMembro
        {
            get => _idMembro;
            set => _idMembro = value ?? "-";
        }

        private DateTimeOffset _dataInicial;
        public DateTimeOffset DataInicial
        {
            get => _dataInicial;
            set => _dataInicial = value.Date;
        }

        private DateTimeOffset? _dataFinal;
        private string _idMembro;

        public DateTimeOffset? DataFinal
        {
            get => _dataFinal;
            set => _dataFinal = value?.Date.AddDays(1).AddSeconds(-1);
        }

        public void SetDataFinalOnUpdate(DateTimeOffset data) =>
            _dataFinal = data.Date.AddSeconds(-1);

        public bool DataFinalValida =>
            !DataFinal.HasValue || DataFinal.Value.Date >= DataInicial;
    }
}