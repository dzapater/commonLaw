using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class VagaDeleteRuleSet : Common.Core.Validation.Validator<Vaga>, IDeleteValidator<Vaga>
    {
        public VagaDeleteRuleSet(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VagaService vagaService) :
            base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(vagaService.VagaNaoFoiCadastrada)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegistroNaoEncontrado)));
        }
    }
}