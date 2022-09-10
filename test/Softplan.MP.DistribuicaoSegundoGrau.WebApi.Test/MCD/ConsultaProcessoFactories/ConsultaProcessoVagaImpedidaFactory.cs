using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD.ConsultaProcessoFactories
{
    public class ConsultaProcessoVagaImpedidaFactory : ConsultaProcessoResponseMessageFactory
    {
        private readonly string _idProcesso;

        public ConsultaProcessoVagaImpedidaFactory(string idProcesso)
        {
            _idProcesso = idProcesso;
        }

        public override ConsultaProcessoResponseMessage GetConsultaProcessoResponseMessage()
            => new ConsultaProcessoResponseMessage
            {
                Id = _idProcesso,
                Status = "MODIFIED",
                Assunto = new AssuntoResponseMessage { Id = 4 },
                Areas = new List<AreaProcessoResponseMessage>
                {
                    new AreaProcessoResponseMessage
                    {
                        Selecionado = true,
                        TipoArea = Area.Indefinida
                    }
                },
                Tarjas = new List<TarjaResponseMessage>
                {
                    new TarjaResponseMessage
                    {
                        Descricao = "TarjaDesc",
                        Id = 1,
                        Prioridade = 2,
                        FlagTj = "Flag",
                        CodigoTarjaCor = 3
                    }
                }
            };

    }
}