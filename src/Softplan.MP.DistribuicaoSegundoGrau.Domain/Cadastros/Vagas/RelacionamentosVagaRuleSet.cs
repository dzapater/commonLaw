using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class RelacionamentosVagaRuleSet : Common.Core.Validation.Validator<Vaga>
    {
        public RelacionamentosVagaRuleSet(IStringLocalizer<DomainResources> localizer)
        {
            RuleFor(x => x.Orgao.Id).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.OrgaoNull)));

            RuleFor(x => x.Orgao.IdTipoOrgao).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.TipoOrgaoNull)));

            RuleFor(x => x.ProcuradorTitular.Id).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.ProcuradorTitularNull)));

            RuleFor(x => x.IdInstalacao).NotEmpty()
                .WithMessage(localizer.GetString(nameof(DomainResources.InstalacaoNull)));
        }
    }
}