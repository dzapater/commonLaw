using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoReadModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool ExisteRegraPendente { get; set; }
        public int QuantidadeVagasVinculadas { get; set; }
        public int QuantidadeVagasVinculadasAtivas { get; set; }
        public int QuantidadeCriteriosVinculados { get; set; }
        public Area? Area { get; set; }
        public VariavelEquilibrio VariavelEquilibrio { get; set; }
        public EscopoEquilibrio EscopoEquilibrio { get; set; }
        public CriterioEspecialidade Especialidade { get; set; }
        public DateTimeOffset DataAtualizacao { get; set; }
        public string Criterios => $"{Area}; {nameof(Especialidade)} {Especialidade?.Descricao ?? "Indefinida"}; +{QuantidadeCriteriosVinculados}";
        public TipoProcesso? TipoProcesso { get; set; }
        public Situacao Situacao { get; set; }
        public int CdLocal { get; set; }
        public static RegraDistribuicaoReadModel New(RegraDistribuicao item) => SelectNew.Compile().Invoke(new RegraDistribuicaoEspecialidadeReadModel{Regra = item});

        public static Expression<Func<RegraDistribuicaoEspecialidadeReadModel, RegraDistribuicaoReadModel>> SelectNew => item => new RegraDistribuicaoReadModel
        {
            Id = item.Regra.Id, 
            Descricao = item.Regra.Descricao, 
            Ativo = item.Regra.Ativo, 
            DataAtualizacao = item.Regra.Metadata.DataAtualizacao,
            Area = item.Regra.Area, 
            Especialidade = item.Especialidade, 
            EscopoEquilibrio = item.Regra.EscopoEquilibrio, 
            VariavelEquilibrio = item.Regra.VariavelEquilibrio,
            QuantidadeVagasVinculadas = item.QuantidadeVinculosTotal,
            QuantidadeVagasVinculadasAtivas = item.QuantidadeVinculosAtivos,
            QuantidadeCriteriosVinculados = item.Regra.Classes.Count + item.Regra.Assuntos.Count + item.Regra.Tarjas.Count + item.Regra.OrgaosJulgadores.Count + item.Regra.Unidades.Count 
                                            + (item.Regra.TipoProcesso != null ? 0 : 1) + (item.Regra.Especialidades.Any() ? item.Regra.Especialidades.Count - 1 : 0), 
            TipoProcesso = item.Regra.TipoProcesso,
            Situacao = SetSituacao(item.Regra.Ativo, item.QuantidadeVinculosAtivos),
            CdLocal = item.Regra.CdLocal
        };

        private static Situacao SetSituacao(bool ativo, int quantidadeVinculosAtivos)
        {
            if (!ativo) return Situacao.Desativada;
            if (quantidadeVinculosAtivos > 0) return Situacao.Ativa;
            return Situacao.Pendente;
        }
    }
}