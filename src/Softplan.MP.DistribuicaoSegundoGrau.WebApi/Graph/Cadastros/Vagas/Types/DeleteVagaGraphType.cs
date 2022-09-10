using Softplan.Common.Graph.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class DeleteVagaGraphType : Softplan.Common.Graph.Types.InputObjectGraphType<Domain.Cadastros.Vagas.Vaga>
    {
        public DeleteVagaGraphType(IDescriptionProvider provider) :
            base(provider)
        {
            Field(x => x.Id);
        }
    }
}