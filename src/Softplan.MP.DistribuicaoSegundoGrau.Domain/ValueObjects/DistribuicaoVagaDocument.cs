using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.ValueObjects
{
    public class DistribuicaoVagaDocument
    {
        public int IdVaga { get; set; }
        public int IdRegraDistribuicao { get; set; }
        public EscopoEquilibrio EscopoEquilibrio { get; set; }
        public VariavelEquilibrio VariavelEquilibrio { get; set; }
        public int Distribuicao { get; set; }
        public int Compensacao { get; set; }
        public int DistribuicaoPorVolume { get; set; }
        public int CompensacaoPorVolume { get; set; }
        public Vaga Vaga { get; set; }
        
        public static Expression<Func<VinculoVagaRegraDistribuicao, DistribuicaoVagaDocument>> SelectNewGlobal => item =>
            new DistribuicaoVagaDocument
            {
                IdVaga = item.IdVaga,
                IdRegraDistribuicao = item.IdRegraDistribuicao,
                EscopoEquilibrio = item.RegraDistribuicao.EscopoEquilibrio,
                VariavelEquilibrio = item.RegraDistribuicao.VariavelEquilibrio,
                Distribuicao = item.Vaga.Distribuicoes,
                Compensacao = item.Vaga.Compensacao,
                DistribuicaoPorVolume = item.Vaga.DistribuicaoPorVolume,
                CompensacaoPorVolume = item.Vaga.CompensacaoPorVolume,
                Vaga = item.Vaga
            };
        
        public static Expression<Func<VinculoVagaRegraDistribuicao, DistribuicaoVagaDocument>> SelectNewLocal => item =>
            new DistribuicaoVagaDocument
            {
                IdVaga = item.IdVaga,
                IdRegraDistribuicao = item.IdRegraDistribuicao,
                EscopoEquilibrio = item.RegraDistribuicao.EscopoEquilibrio,
                VariavelEquilibrio = item.RegraDistribuicao.VariavelEquilibrio,
                Distribuicao = item.DistribuicaoPorProcesso,
                Compensacao = item.CompensacaoPorProcesso,
                DistribuicaoPorVolume = item.DistribuicaoPorVolume,
                CompensacaoPorVolume = item.CompensacaoPorVolume,
                Vaga = item.Vaga
            };
    }
}