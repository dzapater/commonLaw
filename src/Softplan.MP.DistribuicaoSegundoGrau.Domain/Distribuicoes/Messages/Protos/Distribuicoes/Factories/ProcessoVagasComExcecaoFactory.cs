using System.Collections.Generic;
using System.Linq;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories
{
    public class ProcessoVagasComExcecaoFactory : MessageFactory
    {
        public ProcessoVagasComExcecaoFactory(ICollection<Vaga> vagas, string motivo)
        {
            DomainEvent = new ProcessoVagasComExcecao
            {
                VagasRemovidas =
                {
                    vagas.Select(x => new VagasComExcecaoRemovida
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