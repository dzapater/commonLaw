using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class HistoricoCompensacaoRegraReadModel
    {
        public string Motivo { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public DateTimeOffset DataRegistro { get; set; }
        public int Compensado { get; set; }

        public static Expression<Func<CompensacaoLog, HistoricoCompensacaoRegraReadModel>> SelectNew => item => new HistoricoCompensacaoRegraReadModel
        {
            Motivo = item.Motivo,
            Compensado = item.Valor,
            Descricao = item.Vaga.Descricao,
            Usuario = item.Metadata.UsuarioInclusao,
            DataRegistro = item.Metadata.DataInclusao
        };
    }
}