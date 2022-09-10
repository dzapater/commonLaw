using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD.ConsultaProcessoFactories
{ 
    public class ConsultaProcessoDefaultFactory : ConsultaProcessoResponseMessageFactory
    {
        private readonly string _idProcesso;

        public ConsultaProcessoDefaultFactory(string idProcesso)
        {
            _idProcesso = idProcesso;
        }

        public override ConsultaProcessoResponseMessage GetConsultaProcessoResponseMessage()
            => new ConsultaProcessoResponseMessage
            {
                Id = _idProcesso,
                Status = _idProcesso.Equals("LOTACAO_INVALIDA") ? "READ_ONLY" : "MODIFIED",
                Areas = new List<AreaProcessoResponseMessage>
                {
                    new AreaProcessoResponseMessage
                    {
                        Selecionado = true,
                        TipoArea = Area.Ambas
                    }
                },
                Tarjas = new List<TarjaResponseMessage>
                {
                    new TarjaResponseMessage
                    {
                        Descricao = "TarjaDescDefault",
                        Id = 2,
                        Prioridade = 4,
                        FlagTj = "Flag",
                        CodigoTarjaCor = 5
                    }
                },
                Assunto = new AssuntoResponseMessage()
                {
                    Id = 2,
                    Descricao = "AssuntoDescDefault"
                },
                Especialidade = new EspecialidadeResponseMessage()
                {
                    Id = 2,
                    Descricao = "EspecDescDefault"
                },
                OrgaoJulgador = new OrgaoJulgadorResponseMessage()
                {
                    Id = 10,
                    IdOrigem = "10",
                    IdUnidade = 10,
                    Descricao = "OrgaoJulgadorDefault"
                }
            };
    }
}