using System.Collections.Generic;
using Google.Protobuf;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories
{
    public abstract class MessageFactory
    {
        public IMessage DomainEvent { get; set; }
        
        public static MessageFactory Create(ICollection<Vaga> vagas, string motivo)
        {
            if (motivo.Equals(DomainResources.VagasRemovidasDesvioInvalido))
                return new VagasRemovidasParaDistribuicaoCriterioDesvioFactory(vagas, motivo);
            
            if (motivo.Equals(DomainResources.VagasRemovidasExcecaoDistribuicao))
                return new ProcessoVagasComExcecaoFactory(vagas, motivo);

            if (motivo.Equals(DomainResources.VagasRemovidasDistribuicaoMesmaVaga))
                return new ProcessoVagasRemovidasDistribuicaoMesmaVagaFactory(vagas, motivo);

            return default;
        }
        
        public static MessageFactory Create(ICollection<ImpedimentoProcesso> impedimentos)
            => new VagasForamImpedidasParaDistribuicaoFactory(impedimentos);
    }
}