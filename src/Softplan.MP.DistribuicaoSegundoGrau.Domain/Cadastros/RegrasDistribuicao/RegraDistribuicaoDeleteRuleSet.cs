using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoDeleteRuleSet : Common.Core.Validation.Validator<RegraDistribuicao>, IDeleteValidator<RegraDistribuicao>
    {
        public RegraDistribuicaoDeleteRuleSet(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, RegraDistribuicaoService regraDistribuicaoService) :
            base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(regraDistribuicaoService.RegraNaoFoiUtilizadaNaDistribuicao)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegraUtilizadaNaDistribuicao)));
            RuleFor(x => x.Id).Must(regraDistribuicaoService.RegraSemVagaDistribuida)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegraUtilizadaNaDistribuicao)));
        }
    }
}