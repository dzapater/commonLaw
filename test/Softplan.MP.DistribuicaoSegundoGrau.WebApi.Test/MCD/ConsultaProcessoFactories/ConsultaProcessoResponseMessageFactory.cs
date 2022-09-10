using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD.ConsultaProcessoFactories
{
    public abstract class ConsultaProcessoResponseMessageFactory
    {
        public static ConsultaProcessoResponseMessageFactory Create(string idProcesso)
            => idProcesso switch
            {
                "PROCESSO_INVALIDO" => null,
                "PROCESSO_VAGA_IMPEDIDA" => new ConsultaProcessoVagaImpedidaFactory(idProcesso),
                _ => new ConsultaProcessoDefaultFactory(idProcesso)
            };
        
        public abstract ConsultaProcessoResponseMessage GetConsultaProcessoResponseMessage();
    }
}