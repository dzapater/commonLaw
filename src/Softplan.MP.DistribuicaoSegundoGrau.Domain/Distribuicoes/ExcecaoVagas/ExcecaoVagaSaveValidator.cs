using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaSaveValidator : Common.Core.Validation.Validator<ExcecaoVaga>, ISaveValidator<ExcecaoVaga>, IUpdateValidator<ExcecaoVaga>
    {
        public ExcecaoVagaSaveValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, ExcecaoVagaService ExcecaoVagaService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(ExcecaoVagaService.CriteriosNaoForamCadastrados)
                .WithMessage(localizer.GetString(nameof(DomainResources.ExcecaoJaCadastrada)));            
            RuleFor(x => x.IdVaga).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.ObrigadoInformarIdVaga)));            
            RuleFor(x => x.Metadata.Uuid).Must(ExcecaoVagaService.ExcecaoNaoForamCadastradas)
                .WithMessage(localizer.GetString(nameof(DomainResources.NenhumaExcecaoCadastrada)));
        }
    }
}