using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using IPropertyNameNormalizer = Softplan.Common.Core.Validation.IPropertyNameNormalizer;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos
{
    public class AnaliseDistribuicaoPorSorteioValidator : Common.Core.Validation.Validator<AnaliseProcesso>
    {
        public AnaliseDistribuicaoPorSorteioValidator(IPropertyNameNormalizer propertyNameNormalizer) : base(propertyNameNormalizer)
        {
            When(x => x.TipoDistribuicao == TipoDistribuicao.Sorteio, () => { });
        }
    }
}