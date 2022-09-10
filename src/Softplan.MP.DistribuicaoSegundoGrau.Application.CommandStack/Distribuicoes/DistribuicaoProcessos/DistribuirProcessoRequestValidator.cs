using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Exceptions;
using Softplan.Common.Exceptions.Errors;
using Softplan.Common.MessageBus.Abstractions.Middlewares;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuirProcessoRequestValidator : Common.Core.Validation.Validator<DistribuirProcessoRequest>, IMessageSendMiddleware<DistribuirProcessoRequest>
    {
        private readonly ICrudService<AnaliseProcesso, IdAnaliseProcesso> _analiseProcessoService;
        private readonly IReadRepository<ImpedimentoProcesso> _impedimentosProcessoRepository;
        private readonly IReadRepository<Vaga> _vagaRepository;
        private readonly ICrudService<ImpedimentoDistribuicaoLog, IdImpedimentoDistribuicaoLog> _impedimentoLogService;
        private readonly IStringLocalizer _stringLocalizer;

        public DistribuirProcessoRequestValidator(ICrudService<AnaliseProcesso, IdAnaliseProcesso> analiseProcessoService, IReadRepository<ImpedimentoProcesso> impedimentosProcessoRepository,
            IStringLocalizer<DomainResources> stringLocalizer, IReadRepository<Vaga> vagaRepository,
            ICrudService<ImpedimentoDistribuicaoLog, IdImpedimentoDistribuicaoLog> impedimentoLogService)
        {
            _analiseProcessoService = analiseProcessoService;
            _impedimentosProcessoRepository = impedimentosProcessoRepository;
            _stringLocalizer = stringLocalizer;
            _vagaRepository = vagaRepository;
            _impedimentoLogService = impedimentoLogService;
        }

        public async Task ExecuteAsync(DistribuirProcessoRequest message)
        {
            await ValidaRequisição(message);
            await PreencheDadosVaga(message);
            if (message.TipoDistribuicao.Equals(TipoDistribuicao.Prevencao))
                await ValidaVagaImpedida(message);
            await GravarAnalise(message);
        }

        private async Task ValidaRequisição(DistribuirProcessoRequest message)
        {
            RuleFor(x => x.IdProcesso).NotEmpty();
            RuleFor(x => x.IdVaga).NotEmpty();
            await this.ValidateAndThrowAsync(message);
        }

        private async Task PreencheDadosVaga(DistribuirProcessoRequest message)
        {
            var vaga = await _vagaRepository.GetFirstAsync(x => x.Id.Equals(message.IdVaga));
            message.CodigoForoDestino = vaga.IdInstalacao;
            message.CodigoTipoLocalDestino = vaga.Orgao.IdTipoOrgao;
            message.CodigoLocalDestino = vaga.Orgao.Id;
        }

        private async Task ValidaVagaImpedida(DistribuirProcessoRequest message)
        {
            var impedimentos = (await _impedimentosProcessoRepository.GetAllEnumerableAsync(x =>
                x.IdProcesso.Equals(message.IdProcesso), default)).ToArray();

            if (impedimentos.Any(x => x.IdVaga.Equals(message.IdVaga)))
            {
                var domainEvent = MessageFactory.Create(impedimentos).DomainEvent;
                var logs = ImpedimentoDistribuicaoLog.Create(message, domainEvent);
                await _impedimentoLogService.AddAsync(logs);
                throw new BusinessException(new Error(
                    nameof(DomainResources.VagaImpedidaParaDistribuicao), _stringLocalizer.GetString(DomainResources.VagaImpedidaParaDistribuicao)));
            }
        }

        private async Task GravarAnalise(DistribuirProcessoRequest message)
        {
            var analise = MapAnaliseProcesso(message);
            var domainModel = await _analiseProcessoService.GetAsync(analise);
            await (domainModel == default
                ? _analiseProcessoService.AddAsync(analise)
                : _analiseProcessoService.UpdateAsync(analise));
        }

        private static AnaliseProcesso MapAnaliseProcesso(DistribuirProcessoRequest message)
            => new AnaliseProcesso
            {
                IdProcesso = message.IdProcesso, TipoDistribuicao = message.TipoDistribuicao,
                IdVaga = message.IdVaga, Motivo = message.Motivo
            };
    }
}