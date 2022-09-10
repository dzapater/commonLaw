using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoDeleteValidator : Common.Core.Validation.Validator<ImpedimentoProcesso>, IDeleteValidator<ImpedimentoProcesso>
    {
        public ImpedimentoProcessoDeleteValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, ImpedimentoProcessoService impedimentoProcessoService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(impedimentoProcessoService.ImpedimentoNaoCadastrado)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegistroNaoEncontrado)));
            RuleFor(x => x.IdProcesso).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.IdImpedimento).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
        }
    }
}