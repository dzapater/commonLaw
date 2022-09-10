using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoSaveValidator : Common.Core.Validation.Validator<ImpedimentoProcesso>, ISaveValidator<ImpedimentoProcesso>
    {
        public ImpedimentoProcessoSaveValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, ImpedimentoProcessoService impedimentoProcessoService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.IdProcesso).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.IdVaga).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.Motivo).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.IdVaga).Must(impedimentoProcessoService.VagaEstaAtiva)
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));
            RuleFor(x => x.Metadata.Uuid).Must(impedimentoProcessoService.ImpedimentoJaCadastrado)
                .WithMessage(localizer.GetString(nameof(DomainResources.ImpedimentoJaCadastrado)));
        }
    }
}