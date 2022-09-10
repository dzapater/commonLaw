using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Processos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoReadModel
    {
        public string IdProcesso { get; set; }        
        public string Motivo { get; set; }        
        public TipoDistribuicao TipoDistribuicao { get; set; } = TipoDistribuicao.Indefinida;
        public AreaAtuacao AreaAtuacao { get; set; }
        public Vaga Vaga { get; set; }
        public Processo Processo => new Processo { Id = IdProcesso };
    }
}