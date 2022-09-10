using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    public class VagaReadModelExtension : VagaReadModel
    {
        public static VagaReadModelExtension New(VinculoMembroVaga item) => SelectNew.Compile().Invoke(item);
        
        public new static Expression<Func<VinculoMembroVaga, VagaReadModelExtension>> SelectNew => item => new VagaReadModelExtension
        {
            Id = item.Vaga.Id,
            Descricao = item.Vaga.Descricao,
            Orgao = item.Vaga.Orgao,
            IdInstalacao = item.Vaga.IdInstalacao,
            ProcuradorTitular = new ProcuradorTitular{ Id = item.ProcuradorTitularId ?? "-" },
            EstaAtiva = item.Vaga.EstaAtiva,
            DataAtualizacao = item.Vaga.Metadata.DataAtualizacao,
            Area = item.Vaga.Area,
            PermiteReuPreso = item.Vaga.PermiteReuPreso,
            PermiteDistribuicaoMesmaVaga = item.Vaga.PermiteDistribuicaoMesmaVaga,
            ConsiderarConfiguracoesPrevencao = item.Vaga.ConsiderarConfiguracoesPrevencao,
            Distribuicoes = item.Vaga.Distribuicoes, Compensacao = item.Vaga.Compensacao,
            DistribuicaoPorVolume = item.Vaga.DistribuicaoPorVolume, CompensacaoPorVolume = item.Vaga.CompensacaoPorVolume,
            MembroEmAtividade = new ProcuradorTitular { Id = item.IdMembro ?? "-" },
            PossuiVinculoRegraGlobal = PossuiRegraGlobalVinculada(item.Vaga.RegrasVinculadas.Select(x => x.RegraDistribuicao)),
            IdVinculoRegraGlobal = SetIdVinculoRegraGlobal(item.Vaga.RegrasVinculadas.Select(x => x.RegraDistribuicao)),
            DataFinal = item.DataFinal,
            DataInicial = item.DataInicial, Situacao = SetSituacao(item.IdMembro, item.Vaga.EstaAtiva), CdLocal = item.Vaga.CdLocal};

        private static int? SetIdVinculoRegraGlobal(IEnumerable<RegraDistribuicao> regras)
        => regras?.FirstOrDefault(x => x.EscopoEquilibrio.Equals(EscopoEquilibrio.Global))?.Id;

            private static Situacao SetSituacao(string idMembro, bool estaAtiva)
        {
            if (string.IsNullOrWhiteSpace(idMembro)) return Situacao.Pendente;
            if (idMembro.Equals("DesativacaoPlanejada") || !estaAtiva) return Situacao.Desativada;
            
            return Situacao.Ativa;
        }

        private static bool PossuiRegraGlobalVinculada(IEnumerable<RegraDistribuicao> regras)
            => regras.Any(e => e.EscopoEquilibrio.Equals(EscopoEquilibrio.Global));
    }
}