namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VagaCompensacao : VinculoVagaRegraDistribuicao
    {
        public string Motivo { get; set; }
        public int Compensacao { get; set; }
    }
}
