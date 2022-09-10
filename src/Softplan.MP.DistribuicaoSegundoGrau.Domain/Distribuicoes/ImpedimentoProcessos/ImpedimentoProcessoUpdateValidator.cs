using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoUpdateValidator : Common.Core.Validation.Validator<ImpedimentoProcesso>, IUpdateValidator<ImpedimentoProcesso>
    {
        public ImpedimentoProcessoUpdateValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, ImpedimentoProcessoService impedimentoProcessoService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.IdImpedimento).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));

            Include(new ImpedimentoProcessoSaveValidator(propertyNameNormalizer, localizer, impedimentoProcessoService));
        }
    }
}