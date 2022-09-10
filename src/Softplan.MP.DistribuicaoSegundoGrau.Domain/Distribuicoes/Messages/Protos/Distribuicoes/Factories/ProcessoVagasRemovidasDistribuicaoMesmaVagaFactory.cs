using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories
{
    public class ProcessoVagasRemovidasDistribuicaoMesmaVagaFactory : MessageFactory
    {
        public ProcessoVagasRemovidasDistribuicaoMesmaVagaFactory(ICollection<Vaga> vagas, string motivo)
        {
            DomainEvent = new ProcessoVagasRemovidasDistribuicaoMesmaVaga
            {
                VagasRemovidas =
                {
                    vagas.Select(x => new VagasRemovidasDistribuicaoMesmaVaga
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