using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Softplan.Common.Core;
using Softplan.Common.EntityFrameworkCore.Abstractions.UnitOfWorks;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Jobs
{
    public class DistribuicaoVagaJobApplicationService : UnitOfWorkApplicationService
    {
        private static Lazy<ICrudService<DistribuicaoVagaJob, IdJob>> _crudService;
        private static Lazy<ICrudService<Vaga, IdVaga>> _vagaCrudService;
        private static Lazy<IReadRepository<DistribuicaoVagaJob>> _readRepository;
        private static Lazy<IReadRepository<Vaga>> _vagaReadRepository;
        private static Lazy<IReadRepository<VinculoVagaRegraDistribuicao>> _vinculoVagaRegraReadRepository;
        private static Lazy<ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>> _vinculoVagaRegraCrudService;
        private static Lazy<IReadRepository<RegraDistribuicao>> _regraDistribuicaoReadRepository;
        private static Lazy<IDistribuicaoProcessoRepository> _logRepository;
        private static Lazy<ISoftplanPrincipal> _principal;

        private static ICrudService<DistribuicaoVagaJob, IdJob> CrudService => _crudService.Value;
        private static ICrudService<Vaga, IdVaga> VagaCrudService => _vagaCrudService.Value;
        private static IReadRepository<DistribuicaoVagaJob> ReadRepository => _readRepository.Value;
        private static IReadRepository<Vaga> VagaReadRepository => _vagaReadRepository.Value;
        private static IReadRepository<VinculoVagaRegraDistribuicao> VinculoVagaRegraReadRepository => _vinculoVagaRegraReadRepository.Value;
        private static ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao> VinculoVagaRegraCrudService => _vinculoVagaRegraCrudService.Value;
        private static IReadRepository<RegraDistribuicao> RegraDistribuicaoReadRepository => _regraDistribuicaoReadRepository.Value;
        private static IDistribuicaoProcessoRepository LogRepository => _logRepository.Value;


        public DistribuicaoVagaJobApplicationService(IUnitOfWork unitOfWork, IServiceProvider provider)
            : base(unitOfWork)
        {
            ConfiguraIoC(in provider);
        }
        
        private void ConfiguraIoC(in IServiceProvider serviceProvider)
        {
            _crudService = CriarInstanciaLazy<ICrudService<DistribuicaoVagaJob, IdJob>>(serviceProvider);
            _vagaCrudService = CriarInstanciaLazy<ICrudService<Vaga, IdVaga>>(serviceProvider);
            _readRepository = CriarInstanciaLazy<IReadRepository<DistribuicaoVagaJob>>(serviceProvider);
            _vagaReadRepository = CriarInstanciaLazy<IReadRepository<Vaga>>(serviceProvider);
            _vinculoVagaRegraReadRepository = CriarInstanciaLazy<IReadRepository<VinculoVagaRegraDistribuicao>>(serviceProvider);
            _vinculoVagaRegraCrudService = CriarInstanciaLazy<ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>>(serviceProvider);
            _regraDistribuicaoReadRepository = CriarInstanciaLazy<IReadRepository<RegraDistribuicao>>(serviceProvider);
            _logRepository = CriarInstanciaLazy<IDistribuicaoProcessoRepository>(serviceProvider);
            _principal = CriarInstanciaLazy<ISoftplanPrincipal>(serviceProvider);
        }

        public Task UpdateVagaDistributions()
            => UnitOfWork.ExecuteAsync(async () =>
            {
                var logs = await GetLogs();
                if (logs.Length > 0)
                {
                    var vagas = await GetVagasToUpdate(logs);
                    await UpdateVagas(vagas, logs);
                    var vinculos = await GetVinculosVagaRegraComEscopoLocal(logs);
                    await UpdateVinculosVagaRegra(vinculos, logs);
                    await UpdateJobLogId(logs);
                }
            });
        
        private async Task<DistribuicaoProcessoLog[]> GetLogs()
        {
            var filter = await BuildLogFilter();
            return await LogRepository.LoadLogsAsync(filter);
        }
        
        private async Task<Vaga[]> GetVagasToUpdate(DistribuicaoProcessoLog[] logs)
        {
            var ids =  logs.Select(l => l.DomainEvent).Select(d =>(int) d.IdVaga).ToList();
            var filter = BuildVagaFilter(ids);
            var vagas = await VagaReadRepository.GetAllAsync(filter);
            return vagas.ToArray();
        }

        private async Task<VinculoVagaRegraDistribuicao[]> GetVinculosVagaRegraComEscopoLocal(DistribuicaoProcessoLog[] logs)
        {
            var ids =  logs.Select(l => l.DomainEvent)
                .Where(x => x.IdRegraDistribuicao != null)
                .Select(d =>(int) d.IdRegraDistribuicao).ToList();
            var vinculos = await BuildQuery(ids);
            return vinculos.ToArray();
        }
        
        private async Task UpdateVagas(Vaga[] vagas, DistribuicaoProcessoLog[] logs)
        {
            foreach (var vaga in vagas)
            {
                var domainEvent = logs.Select(l => l.DomainEvent).Where(d =>(int) d.IdVaga == vaga.Id).ToList();
                vaga.Distribuicoes += domainEvent.Count;
                vaga.DistribuicaoPorVolume += domainEvent.Sum(d => d.Volumes);
                await VagaCrudService.UpdateAsync(vaga);
            }
        }

        private async Task UpdateVinculosVagaRegra(VinculoVagaRegraDistribuicao[] vinculos,
            DistribuicaoProcessoLog[] logs)
        {
            foreach (var vinculo in vinculos)
            {
                var domainEvent = logs.Select(l => l.DomainEvent)
                    .Where(d => d.IdRegraDistribuicao != null)
                    .Where(d =>(int) d.IdVaga == vinculo.IdVaga && (int) d.IdRegraDistribuicao == vinculo.IdRegraDistribuicao).ToList();
                if (domainEvent.Any())
                {
                    vinculo.DistribuicaoPorProcesso += domainEvent.Count;
                    vinculo.DistribuicaoPorVolume += domainEvent.Sum(d => d.Volumes);
                    await VinculoVagaRegraCrudService.UpdateAsync(vinculo);
                }
            }
        }
        
        private async Task UpdateJobLogId(DistribuicaoProcessoLog[] logs)
        {
            var job = await ReadRepository.GetFirstAsync(x => x.Id.Equals(nameof(DistribuicaoVagaJob)));
            var lastLogId = (int)logs.Max(l => l.IdLog);
            job.UpdatePayload(new DistVagaJobPayload { LastLogId = lastLogId });
            await CrudService.UpdateAsync(job);
        }

        private async Task<Expression<Func<DistribuicaoProcessoLog, bool>>> BuildLogFilter()
        {
            var job = await ReadRepository.GetFirstAsync(x => x.Id.Equals(nameof(DistribuicaoVagaJob)));
            var lastLogId = job.PayLoadData.LastLogId;
            return log => log.PayloadType.Contains(nameof(VagaFoiSelecionadaParaDistribuicao)) && log.IdLog > lastLogId;
        }
        
        private Expression<Func<Vaga, bool>> BuildVagaFilter(List<int> ids)
        {
            return vaga => ids.Contains(vaga.Id);
        }

        private async Task<IQueryable<VinculoVagaRegraDistribuicao>> BuildQuery(List<int> ids)
        {
            var vinculos = await VinculoVagaRegraReadRepository.GetAllAsync(x => ids.Contains(x.IdRegraDistribuicao));
            var regras = await RegraDistribuicaoReadRepository.GetAllAsync(x =>
                x.EscopoEquilibrio.Equals(EscopoEquilibrio.Local));
            
            return vinculos.Join(
                regras,
                outer => outer.IdRegraDistribuicao,
                inner => inner.Id,
                (outer, inner) => outer);
        }
        
        private static Lazy<T> CriarInstanciaLazy<T>(IServiceProvider serviceProvider)
            => new Lazy<T>(() => (T)serviceProvider.GetService(typeof(T)));
    }
}