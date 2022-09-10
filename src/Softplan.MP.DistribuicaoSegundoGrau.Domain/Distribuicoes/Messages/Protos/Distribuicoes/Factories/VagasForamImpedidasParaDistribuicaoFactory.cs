using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories
{
    public class VagasForamImpedidasParaDistribuicaoFactory : MessageFactory
    {
        public VagasForamImpedidasParaDistribuicaoFactory(ICollection<ImpedimentoProcesso> impedimentos)
        {
            DomainEvent = new VagasForamImpedidasParaDistribuicao
            {
                VagasImpedidas =
                {
                    impedimentos.Select(x => new VagaImpedidaParaDistribuicao
                    {
                        IdVaga = x.IdVaga, Motivo = x.Motivo, Descricao = x.Vaga.Descricao
                    })
                }
            };
        }
    }
}