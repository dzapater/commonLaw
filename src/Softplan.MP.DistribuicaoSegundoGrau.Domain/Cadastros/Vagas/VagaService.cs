using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class VagaService : IDomainService
    {
        public static readonly Guid UUidVagaUtilizadaNaDistribuicao = Guid.NewGuid();
        private readonly ISet<Guid> _vagasJaCadastradas = new HashSet<Guid>();
        private readonly ISet<Guid> _orgaosInvalidos = new HashSet<Guid>();

        public void InformarVagaJaCadastrada(Guid uuid) => _vagasJaCadastradas.Add(uuid);
        public void InformarOrgaoInvalido(Guid uuid) => _orgaosInvalidos.Add(uuid);
        public bool VagaNaoFoiCadastrada(Guid uuid) => !_vagasJaCadastradas.Contains(uuid);
        public bool OrgaoValido(Guid uuid) => !_orgaosInvalidos.Contains(uuid);

        public IQueryable<Vaga> FiltrarVagasJaCadastradas(IQueryable<Vaga> vagasCadastradas,
            Vaga vagaInformada)
            => from rc in vagasCadastradas
                where rc.Id != vagaInformada.Id
                where rc.Descricao.Trim().ToLower().Equals(vagaInformada.Descricao.Trim().ToLower())
                select rc;

        public IQueryable<Vaga> FiltrarOrgaosInvalidos(IQueryable<Vaga> vagasCadastradas,
            Vaga vagaInformada)
            => from rc in vagasCadastradas
                where rc.Id == vagaInformada.Id
                where rc.Orgao.Id != (vagaInformada.Orgao == null ? rc.Orgao.Id : vagaInformada.Orgao.Id)  
                select rc;
    }
}