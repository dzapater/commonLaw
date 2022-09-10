using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class PropriedadesVagaRuleSet : Common.Core.Validation.Validator<Vaga>
    {
        public PropriedadesVagaRuleSet(IStringLocalizer<DomainResources> localizer, VagaService vagaService)
        {
            RuleFor(x => x.Metadata.Uuid).Must(vagaService.VagaNaoFoiCadastrada)
                .WithMessage(localizer.GetString(nameof(DomainResources.VagaJaCadastrada)));

            RuleFor(x => x.Descricao).Must(x => x.Trim().Length > 2)
                .WithMessage(localizer.GetString(nameof(DomainResources.DescricaoMinimumLenght)));
        }
    }
}