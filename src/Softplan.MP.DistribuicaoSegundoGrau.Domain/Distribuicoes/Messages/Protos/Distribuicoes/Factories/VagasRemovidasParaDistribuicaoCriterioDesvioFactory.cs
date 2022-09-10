using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories
{
    public class VagasRemovidasParaDistribuicaoCriterioDesvioFactory : MessageFactory
    {
        public VagasRemovidasParaDistribuicaoCriterioDesvioFactory(ICollection<Vaga> vagas, string motivo)
        {
            DomainEvent = new VagasRemovidasParaDistribuicaoCriterioDesvio
                {
                    VagasRemovidas =
                    {
                        vagas.Select(x => new VagaRemovidaPorDesvioInvalido
                        {
                            IdVaga = x.Id,
                            Descricao = x.Descricao
                        })
                    },
                    Motivo = motivo   
                };
        }
    }
}