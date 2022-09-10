using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoService : IDomainService
    {
        private readonly ISet<Guid> _criteriosCadastrados = new HashSet<Guid>();
        private readonly ISet<Guid> _impedimentosCadastrados = new HashSet<Guid>();

        private bool _vagaAtiva;
        public void InformarImpedimentoJaCadastrado(Guid uuid) => _criteriosCadastrados.Add(uuid);
        public void InformarImpedimentoCadastrado(Guid uuid) => _impedimentosCadastrados.Add(uuid);
        public void InformarVagaAtiva(bool vagaAtiva) => _vagaAtiva = vagaAtiva;
        public bool VagaEstaAtiva(int vagaId) => _vagaAtiva;
        public bool ImpedimentoJaCadastrado(Guid uuid) => !_criteriosCadastrados.Contains(uuid);
        public bool ImpedimentoNaoCadastrado(Guid uuid) => !_impedimentosCadastrados.Contains(uuid);

        public IQueryable<ImpedimentoProcesso> FiltrarImpedimentoJaCadastrado(IQueryable<ImpedimentoProcesso> queryable, ImpedimentoProcesso entidade)
            => from item in queryable
                where item.IdImpedimento != entidade.IdImpedimento
                where item.IdProcesso == entidade.IdProcesso
                where item.IdVaga == entidade.IdVaga
                select item;
    }
}