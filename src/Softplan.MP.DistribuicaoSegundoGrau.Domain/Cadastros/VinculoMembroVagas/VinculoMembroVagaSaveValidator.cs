using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaSaveValidator : Common.Core.Validation.Validator<VinculoMembroVaga>, ISaveValidator<VinculoMembroVaga>, IUpdateValidator<VinculoMembroVaga>
    {
        public VinculoMembroVagaSaveValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VinculoMembroVagaService vinculoMembroVagaService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.IdVaga).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.IdMembro).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.IdMotivoMembroVaga).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));
            Include(new VinculoMembroVagaDateValidator(propertyNameNormalizer, localizer,vinculoMembroVagaService));
        }
    }
}