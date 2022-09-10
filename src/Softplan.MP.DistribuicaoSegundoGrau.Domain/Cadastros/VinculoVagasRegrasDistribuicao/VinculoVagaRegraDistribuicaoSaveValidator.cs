using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoSaveValidator : Common.Core.Validation.Validator<VinculoVagaRegraDistribuicao>, ISaveValidator<VinculoVagaRegraDistribuicao>, IUpdateValidator<VinculoVagaRegraDistribuicao>
    {
        public VinculoVagaRegraDistribuicaoSaveValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VinculoVagaRegraDistribuicaoService regraDistribuicaoService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.IdVaga)
                .NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.IdRegraDistribuicao)
                .NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacaoInvalida)));

            RuleFor(x => x.Metadata.Uuid)
                .Must(x => !regraDistribuicaoService.InformacoesJaVinculadas(x))
                .WithMessage(localizer.GetString(nameof(DomainResources.InformacoesJaVinculadas)));
            
            RuleFor(x => x.Metadata.Uuid)
                .Must(x => !regraDistribuicaoService.RegraGlobalJaVinculadas(x))
                .WithMessage(localizer.GetString(nameof(DomainResources.RegraGlobalJaVinculadas)));
        }
    }
}