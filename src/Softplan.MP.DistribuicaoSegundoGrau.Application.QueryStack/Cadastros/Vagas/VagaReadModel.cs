using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.USR;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    public class VagaReadModel
    {
        public int Id { get; set; }
        public Orgao Orgao { get; set; }
        public int IdInstalacao { get; set; }
        public int Distribuicoes { get; set; }
        public int Compensacao { get; set; }
        public int DistribuicaoPorVolume { get; set; }
        public int CompensacaoPorVolume { get; set; }
        public ProcuradorTitular ProcuradorTitular { get; set; }
        public string Descricao { get; set; }
        public Area Area { get; set; }
        public bool EstaAtiva { get; set; }
        public bool PermiteReuPreso { get; set; }
        public bool PermiteDistribuicaoMesmaVaga { get; set; }
        public bool ConsiderarConfiguracoesPrevencao { get; set; }
        public DateTimeOffset DataAtualizacao { get; set; }
        public TipoLocalReadModel TipoOrgao => new TipoLocalReadModel {Id = Orgao.IdTipoOrgao};
        public ForoReadModel Instalacao => new ForoReadModel {IdForo = IdInstalacao};
        public ProcuradorTitular MembroEmAtividade { get; set; }
        public bool ExisteVagaPendente { get; set; }
        public DateTimeOffset? DataInicial { get; set; }
        public DateTimeOffset? DataFinal { get; set; }
        public Situacao Situacao { get; set; }
        public int CdLocal { get; set; }
        public bool PossuiVinculoRegraGlobal { get; set; }
        public int? IdVinculoRegraGlobal { get; set; }
        
        public static VagaReadModel New(Vaga item) => SelectNew.Compile().Invoke(item);

        public static Expression<Func<Vaga, VagaReadModel>> SelectNew => item => new VagaReadModel
        {
            Id = item.Id,
            Descricao = item.Descricao,
            Orgao = item.Orgao,
            IdInstalacao = item.IdInstalacao,
            ProcuradorTitular = item.ProcuradorTitular,
            EstaAtiva = item.EstaAtiva,
            DataAtualizacao = item.Metadata.DataAtualizacao,
            Area = item.Area,
            PermiteReuPreso = item.PermiteReuPreso,
            PermiteDistribuicaoMesmaVaga = item.PermiteDistribuicaoMesmaVaga,
            ConsiderarConfiguracoesPrevencao = item.ConsiderarConfiguracoesPrevencao,
            Distribuicoes = item.Distribuicoes,
            Compensacao = item.Compensacao,
            DistribuicaoPorVolume = item.DistribuicaoPorVolume,
            CompensacaoPorVolume = item.CompensacaoPorVolume,
            CdLocal = item.CdLocal
        };
    }
}