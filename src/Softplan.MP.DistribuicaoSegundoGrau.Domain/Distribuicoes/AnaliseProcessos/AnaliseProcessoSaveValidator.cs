using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoSaveValidator : Common.Core.Validation.Validator<AnaliseProcesso>, ISaveValidator<AnaliseProcesso>, IUpdateValidator<AnaliseProcesso>
    {
        public AnaliseProcessoSaveValidator(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, AnalisarProcessoService analiseService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(analiseService.LotacaoInvalida)
                .WithMessage(localizer.GetString(nameof(DomainResources.LotacaoUsuarioDiferenteLotacaoProcesso)));
            RuleFor(x => x.Metadata.Uuid).Must(analiseService.ProcessoInvalido)
                .WithMessage(localizer.GetString(nameof(DomainResources.ProcessoSigilosoOuInexistente)));
            RuleFor(x => x.IdProcesso).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.TipoDistribuicao).Must(x => x != TipoDistribuicao.Indefinida)
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            Include(new AnaliseDistribuicaoPorPrevencaoValidator(propertyNameNormalizer, localizer));
            Include(new AnaliseDistribuicaoPorSorteioValidator(propertyNameNormalizer));
        }
    }
}