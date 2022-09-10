using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaDeleteValidator : Common.Core.Validation.Validator<ExcecaoVaga>, IDeleteValidator<ExcecaoVaga>
    {
        public ExcecaoVagaDeleteValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, ExcecaoVagaService ExcecaoVagaService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(ExcecaoVagaService.ExcecaoNaoEncontrada)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegistroNaoEncontrado)));
        }
    }
}