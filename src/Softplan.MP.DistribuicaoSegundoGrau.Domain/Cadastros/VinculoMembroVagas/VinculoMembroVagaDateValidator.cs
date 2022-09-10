using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaDateValidator : Common.Core.Validation.Validator<VinculoMembroVaga>, ISaveValidator<VinculoMembroVaga>, IUpdateValidator<VinculoMembroVaga>
    {
        public VinculoMembroVagaDateValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VinculoMembroVagaService vinculoMembroVagaService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.DataInicial).Must(x => x != DateTime.MinValue)
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.DataFinal).Must(x => x != DateTime.MinValue)
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.DataFinalValida).Equal(true)
                .WithMessage(localizer.GetString(nameof(DomainResources.DataFinalMenorDataInicial)));

            RuleFor(x => x.Metadata.Uuid).Must(x => !vinculoMembroVagaService.InformacoesJaVinculadas(x))
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacoesJaVinculadas)))
                .Must(x => !vinculoMembroVagaService.PeriodoInvalido(x))
                .WithMessage(localizer.GetString(nameof(DomainResources.PeriodoInvalido)));
        }
    }
}