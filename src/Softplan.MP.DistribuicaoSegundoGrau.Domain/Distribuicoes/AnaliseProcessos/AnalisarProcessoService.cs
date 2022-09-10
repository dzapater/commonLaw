using System;
using System.Collections.Generic;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnalisarProcessoService : IDomainService
    {
        private readonly ISet<Guid> _lotacaoInvalida = new HashSet<Guid>();
        private readonly ISet<Guid> _processoInvalido = new HashSet<Guid>();

        public void InformarLotacaoInvalida(Guid uuid) => _lotacaoInvalida.Add(uuid);
        public void InformarProcessoInvalido(Guid uuid) => _processoInvalido.Add(uuid);
        public bool LotacaoInvalida(Guid uuid) => !_lotacaoInvalida.Contains(uuid);
        public bool ProcessoInvalido(Guid uuid) => !_processoInvalido.Contains(uuid);
    }
}