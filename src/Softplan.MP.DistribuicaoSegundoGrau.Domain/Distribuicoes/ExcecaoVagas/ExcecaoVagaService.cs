using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaService : IDomainService
    {
        private readonly ISet<Guid> _criteriosCadastrados = new HashSet<Guid>();        
        private readonly ISet<Guid> _excecoesCadastradas = new HashSet<Guid>();                

        public void NotificarCriteriosJaCadastrados(Guid uuid) => _criteriosCadastrados.Add(uuid);

        public bool CriteriosNaoForamCadastrados(Guid uuid) => !_criteriosCadastrados.Contains(uuid);
        
        public void NotificarNenhumaExcecaoCadastrada(Guid uuid) => _excecoesCadastradas.Add(uuid);

        public bool ExcecaoNaoForamCadastradas(Guid uuid) => _excecoesCadastradas.Contains(uuid);
        
        public bool ExcecaoNaoEncontrada(Guid uuid) => !_excecoesCadastradas.Contains(uuid);

        public IQueryable<ExcecaoVaga> FiltrarCriteriosJaCadastrados(IQueryable<ExcecaoVaga> queryable, ExcecaoVaga entidade)
            => from item in queryable
                where item.Id != entidade.Id
                where item.IdVaga == entidade.IdVaga
                where item.IdAssunto == entidade.IdAssunto
                where item.IdClasse == entidade.IdClasse
                where item.IdEspecialidade == entidade.IdEspecialidade
                where item.IdOrigem == entidade.IdOrigem
                where item.IdUnidade == entidade.IdUnidade
                where item.IdOrgaoJulgador == entidade.IdOrgaoJulgador
               select item;

        public bool ExisteExcecaoCadastrada(ExcecaoVaga entidade)
            => !(entidade.IdAssunto == null && 
                    entidade.IdClasse == null && 
                    entidade.IdEspecialidade == null && 
                    entidade.IdOrigem == null && 
                    entidade.IdUnidade == null && 
                    entidade.IdOrgaoJulgador == null);
    }
}