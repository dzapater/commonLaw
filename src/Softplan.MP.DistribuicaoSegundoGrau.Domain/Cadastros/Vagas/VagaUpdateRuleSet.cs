using FluentValidation;
using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class VagaUpdateRuleSet : Common.Core.Validation.Validator<Vaga>, IUpdateValidator<Vaga>
    {
        public VagaUpdateRuleSet(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VagaService vagaService, VinculoVagaRegraDistribuicaoService vinculoVagaRegraDistribuicaoService) : base(propertyNameNormalizer)
        {
            RuleFor(x => x.Metadata.Uuid).Must(vagaService.OrgaoValido)
                .WithMessage(localizer.GetString(nameof(DomainResources.InvalidUpdateVagaOrgao)));

            RuleFor(x => x.Metadata.Uuid).Must(vinculoVagaRegraDistribuicaoService.CompensacaoInvalida)
                .WithMessage(localizer.GetString(nameof(DomainResources.ValorCompensacaoMaior)));

            RuleFor(x => x.Metadata.Uuid).Must(vinculoVagaRegraDistribuicaoService.MotivoInvalido)
                .WithMessage(localizer.GetString(nameof(DomainResources.MotivoIncorreto)));

            RuleFor(x => x.Metadata.Uuid).Must(vinculoVagaRegraDistribuicaoService.RegraInvalida)
                .WithMessage(localizer.GetString(nameof(DomainResources.RegraInvalida)));

            Include(new PropriedadesVagaRuleSet(localizer, vagaService));
            Include(new RelacionamentosVagaRuleSet(localizer));
        }
    }
}