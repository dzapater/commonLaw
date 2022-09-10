namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes
{
    public class DistribuicaoVagaJob : Job<DistVagaJobPayload>
    {
        public DistribuicaoVagaJob()
        {
            Id = nameof(DistribuicaoVagaJob);
        }
    }
}