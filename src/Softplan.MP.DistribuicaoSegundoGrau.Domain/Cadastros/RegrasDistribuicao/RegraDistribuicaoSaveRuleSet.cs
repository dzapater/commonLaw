using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoSaveRuleSet : Common.Core.Validation.Validator<RegraDistribuicao>, ISaveValidator<RegraDistribuicao>, IUpdateValidator<RegraDistribuicao>
    {
        public RegraDistribuicaoSaveRuleSet(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, RegraDistribuicaoService regraDistribuicaoService) :
            base(propertyNameNormalizer)
        {
            
            RuleFor(x => x.Descricao).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.DescricaoNaoInformada)));
            RuleFor(x => x.VariavelEquilibrio).Must(x => x != VariavelEquilibrio.Indefinido)
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.EscopoEquilibrio).Must(x => x !=EscopoEquilibrio.Indefinido)
                .WithMessage(localizer.GetString(nameof(DomainResources.CampoObrigatorioNaoInformado)));
            RuleFor(x => x.Metadata.Uuid).Must(regraDistribuicaoService.RegraContemCriterios)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegraSemCriterios)));
            RuleFor(x => x.Metadata.Uuid).Must(regraDistribuicaoService.RegraNaoFoiCadastrada)
                .WithMessage(localizer.GetString(nameof(DomainResources.DadosJaCadastrados)));
            RuleFor(x => x.Metadata.Uuid).Must(regraDistribuicaoService.OrgaoJulgadorInvalidoParaUnidadeInformada)
                .WithMessage(localizer.GetString(nameof(DomainResources.OrgaoJulgadorInvalidoParaUnidadeInformada)));

        }
    }
}