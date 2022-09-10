using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages
{
    public class AreaProcessoResponseMessage
    {
        public Area TipoArea { get; set; }
        public bool Selecionado { get; set; }
    }
}