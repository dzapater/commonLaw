namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas
{
    public class Orgao
    {
        public int Id { get; set; } = default;
        public int IdTipoOrgao { get; set; } = default;
        public int IdForo => (int)Foro.Default;
    }
}