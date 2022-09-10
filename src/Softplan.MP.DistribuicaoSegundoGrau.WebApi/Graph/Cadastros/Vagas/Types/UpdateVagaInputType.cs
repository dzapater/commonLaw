namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.Vagas.Types
{
    public class UpdateVagaInputType : VagaInputType
    {
        public UpdateVagaInputType()
        {
            Field(x => x.Id);
        }
    }
}