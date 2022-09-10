using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Softplan.Common.Core;
using Softplan.Common.Core.Entities;
using Softplan.Common.EntityFrameworkCore.Abstractions.UnitOfWorks;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos
{
    class DistribuicaoProcessoApplicationService : UnitOfWorkApplicationService
    {
        private readonly ICrudService<DistribuicaoProcesso, SimpleId<long>> _crudService;
        private readonly IReadRepository<DistribuicaoProcesso> _readRepository;
        private readonly ISoftplanPrincipal _principal;

        public DistribuicaoProcessoApplicationService(IUnitOfWork unitOfWork, ISoftplanPrincipal principal,
            ICrudService<DistribuicaoProcesso, SimpleId<long>> crudService, IReadRepository<DistribuicaoProcesso> readRepository)
            : base(unitOfWork)
        {
            _principal = principal;
            _crudService = crudService;
            _readRepository = readRepository;
        }

        public Task LogarDistribuicaoProcessoAsync(LogarDistribuicaoProcessoCommand command)
            => UnitOfWork.ExecuteAsync(async () =>
            {
                var entidade = await CreateDistribuicaoProcessoAsync(command);
                await _crudService.AddAsync(entidade);
            });

        private async Task<DistribuicaoProcesso> CreateDistribuicaoProcessoAsync(LogarDistribuicaoProcessoCommand command)
        {
            var entidade = DistribuicaoProcesso.Create(command);
            entidade.Metadata.UsuarioAtualizacao = _principal.Identity?.Name ?? string.Empty;
            entidade.Metadata.DataAtualizacao = await _readRepository.GetDateTimeDbAsync();

            foreach (var domainEvent in MapEventosDistribuicao(entidade, command))
                entidade.AddLog(domainEvent);

            return entidade;
        }

        private IEnumerable<IMessage> MapEventosDistribuicao(DistribuicaoProcesso distribuicaoProcesso, LogarDistribuicaoProcessoCommand command)
        {
            if (command.TipoDistribuicao == TipoDistribuicao.Prevencao)
                yield return MapProcessoFoiDistribuidoPorPrevencao(distribuicaoProcesso);
            
            if (command.TipoDistribuicao == TipoDistribuicao.Sorteio)
                yield return MapProcessoFoiDistribuidoPorSorteio(distribuicaoProcesso);                                     

            if (command.IdVaga != default) 
                yield return MapVagaFoiSelecionadaParaDistribuicao(command);

            if (command.IdLoteDistribuicao != default)  
                yield return MapRemessaProcessoFoiAgendada(command);
        }

        private ProcessoFoiDistribuidoPorPrevencao MapProcessoFoiDistribuidoPorPrevencao(DistribuicaoProcesso distribuicaoProcesso)
            => new ProcessoFoiDistribuidoPorPrevencao
            {
                IdProcesso = distribuicaoProcesso.IdProcesso, Usuario = distribuicaoProcesso.Metadata.UsuarioAtualizacao,
                DataOcorrencia = Timestamp.FromDateTimeOffset(distribuicaoProcesso.Metadata.DataAtualizacao)
            };
        
        private ProcessoFoiDistribuidoPorSorteio MapProcessoFoiDistribuidoPorSorteio(DistribuicaoProcesso distribuicaoProcesso)
            => new ProcessoFoiDistribuidoPorSorteio
            {
                IdProcesso = distribuicaoProcesso.IdProcesso, Usuario = distribuicaoProcesso.Metadata.UsuarioAtualizacao,
                DataOcorrencia = Timestamp.FromDateTimeOffset(distribuicaoProcesso.Metadata.DataAtualizacao)
            };

        private VagaFoiSelecionadaParaDistribuicao MapVagaFoiSelecionadaParaDistribuicao(LogarDistribuicaoProcessoCommand command)
            => new VagaFoiSelecionadaParaDistribuicao
            {
                IdVaga = command.IdVaga,
                IdRegraDistribuicao = command.IdRegraDistribuicao,
                IdProcesso = command.IdProcesso,
                Volumes = command.Volumes
            };

        private RemessaProcessoFoiAgendada MapRemessaProcessoFoiAgendada(LogarDistribuicaoProcessoCommand command)
            => new RemessaProcessoFoiAgendada
            {
                IdProcesso = command.IdProcesso, CodigoForoDestino = command.CodigoForoDestino,
                CodigoLocalDestino = command.CodigoLocalDestino, CodigoTipoLocalDestino = command.CodigoTipoLocalDestino,
                IdLoteDistribuicao = command.IdLoteDistribuicao
            };
    }
}