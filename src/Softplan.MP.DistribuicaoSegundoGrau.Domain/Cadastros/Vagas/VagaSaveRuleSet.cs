using Microsoft.Extensions.Localization;
using Softplan.Common.Services.Abstractions.Validations;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class VagaSaveRuleSet : Common.Core.Validation.Validator<Vaga>, ISaveValidator<Vaga>
    {
        public VagaSaveRuleSet(IPropertyNameNormalizer propertyNameNormalizer,
            IStringLocalizer<DomainResources> localizer, VagaService vagaService) : base(propertyNameNormalizer)
        {
            Include(new PropriedadesVagaRuleSet(localizer, vagaService));
            Include(new RelacionamentosVagaRuleSet(localizer));
        }
    }
}