using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios
{
    public class CriterioOrgaoJulgador
    {
        public int Id { get; set; }        
        public int IdOrigem { get; set; }        
        public long IdOrgaoJulgador { get; set; }
        public long IdUnidade { get; set; }
        public string IdTipoCadastro => (Origem)IdOrigem switch
        {
            Origem.PrimeiroGrau => "0801",
            _ => "0802"
        };

        public string Descricao { get; set; }
    }
}