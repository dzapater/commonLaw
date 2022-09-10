using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaService : IDomainService
    {
        private readonly ISet<Guid> _informacoesVinculadas = new HashSet<Guid>();
        private readonly ISet<Guid> _periodoInvalido = new HashSet<Guid>();
        
        public static readonly Guid UUidMembroVagaUtilizada = Guid.NewGuid();
        public void NotificarInformacoesJaVinculadas(Guid uuid) => _informacoesVinculadas.Add(uuid);
        public bool InformacoesJaVinculadas(Guid uuid) => _informacoesVinculadas.Contains(uuid);
        public void NotificarPeriodo(Guid uuid) => _periodoInvalido.Add(uuid);
        public bool PeriodoInvalido(Guid uuid) => _periodoInvalido.Contains(uuid);

        public IQueryable<VinculoMembroVaga> FiltrarIdVaga(IQueryable<VinculoMembroVaga> queryable, VinculoMembroVaga input)
            => from item in queryable
                where item.Id != input.Id && item.IdVaga == input.IdVaga
                select item;
        
        public IQueryable<VinculoMembroVaga> FiltrarInformacoesJaVinculadas(IQueryable<VinculoMembroVaga> queryable, VinculoMembroVaga entidade)
            => from item in queryable
                      where item.Id != entidade.Id
                      && item.IdVaga == entidade.IdVaga
                      && item.IdMembro == entidade.IdMembro
                      && item.IdMotivoMembroVaga == entidade.IdMotivoMembroVaga
                      && item.DataInicial == entidade.DataInicial                      
                    select item;

        public IQueryable<VinculoMembroVaga> ValidacaoVinculoVencido(IQueryable<VinculoMembroVaga> queryable,
            VinculoMembroVaga entidade)
            => from item in queryable
                where
                    item.Id == entidade.Id && item.DataFinal <= DateTime.Now
                select item;

        public IQueryable<VinculoMembroVaga> ValidarPeriodoEntreVigente(IQueryable<VinculoMembroVaga> queryable,
            VinculoMembroVaga input)
            => FiltrarIdVaga(queryable, input).Where(x =>
                x.DataInicial <= input.DataInicial &&
                x.DataFinal > input.DataInicial ||
                input.DataFinal.HasValue &&
                x.DataInicial <= input.DataFinal.Value.Date &&
                x.DataFinal >= input.DataFinal);

        public IQueryable<VinculoMembroVaga> ValidarPeriodoContemVigente(IQueryable<VinculoMembroVaga> queryable,
            VinculoMembroVaga input)
        => FiltrarIdVaga(queryable, input).Where(x =>
            x.DataInicial >= input.DataInicial &&
            (!input.DataFinal.HasValue ||
             x.DataInicial <= input.DataFinal.Value.Date));

        public IQueryable<VinculoMembroVaga> VagaVinculoAtivo(IQueryable<VinculoMembroVaga> queryable, VinculoMembroVaga entidade)
            => from item in queryable
                where item.IdVaga == entidade.IdVaga
                      && item.DataFinal == null
                      && item.DataInicial < entidade.DataInicial
                orderby item.DataInicial descending
                select item;
    }
}