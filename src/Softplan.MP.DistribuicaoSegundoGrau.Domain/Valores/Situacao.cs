using System.ComponentModel;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores
{
    public enum Situacao
    {
        [Description("Vaga Ativada")]
        Ativa,
        [Description("Vaga Desativada")]
        Desativada,
        [Description("Vaga Pendente")]
        Pendente,
        [Description("DesativacaoPlanejada")]
        DesativacaoPlanejada
    }
}