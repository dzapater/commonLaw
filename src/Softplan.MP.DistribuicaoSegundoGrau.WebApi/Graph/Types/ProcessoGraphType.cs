using Softplan.Common.Graph.Types.Federation;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Processos;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types
{
    public class ProcessoGraphType : FederatedObjectGraphType<Processo>
    {
        public ProcessoGraphType() : base("MCD")
        {
            Name = "ProcessoResponseMessageGraphType";
            Key(x => x.Id).Name("id");
        }
    }
}