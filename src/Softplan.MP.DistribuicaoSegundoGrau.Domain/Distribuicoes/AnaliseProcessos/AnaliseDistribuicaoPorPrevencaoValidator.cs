using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnaliseDistribuicaoPorPrevencaoValidator : Common.Core.Validation.Validator<AnaliseProcesso>
    {
        public AnaliseDistribuicaoPorPrevencaoValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer) : base(propertyNameNormalizer)
        {
            When(x => x.TipoDistribuicao == TipoDistribuicao.Prevencao, () =>
            {
                RuleFor(x => x.IdVaga).NotEmpty()
                    .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
                RuleFor(x => x.Motivo).NotNull()
                    .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
                RuleFor(x => x.Motivo).MinimumLength(3)
                    .WithMessage(localizer.GetString(nameof(DomainResources.MotivoMinimumLenght)));
            });
        }
    }
}