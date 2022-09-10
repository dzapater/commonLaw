namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages
{
    public class TarjaResponseMessage
    {
        public decimal Id { get; set; }
        public string Descricao { get; set; }
        public decimal Prioridade { get; set; }
        public string FlagTj { get; set; }
        public decimal CodigoTarjaCor {get; set; }
    }
}