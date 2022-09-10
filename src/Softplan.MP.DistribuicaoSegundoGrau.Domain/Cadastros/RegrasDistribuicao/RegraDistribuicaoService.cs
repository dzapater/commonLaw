using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoService : IDomainService
    {
        public static readonly Guid UUidRegraUtilizadaNaDistribuicao = Guid.NewGuid();
        private readonly ISet<Guid> _criteriosCadastrados = new HashSet<Guid>();
        private readonly ISet<int> _vagasComDistribuicao = new HashSet<int>();
        private readonly ISet<Guid> _semCriterios = new HashSet<Guid>();
        private readonly ISet<Guid> _orgaoJulgadorInvalido = new HashSet<Guid>();

        public void InformarOrgaoJulgadorInvalido(Guid uuid) => _orgaoJulgadorInvalido.Add(uuid);
        public void InformarRegraJaCadastrada(Guid uuid) => _criteriosCadastrados.Add(uuid);
        public void InformarVagaComDistribuicao(int id) => _vagasComDistribuicao.Add(id);
        public void InformarRegraSemCriterio(Guid uuid) => _semCriterios.Add(uuid);
        public bool RegraNaoFoiUtilizadaNaDistribuicao(Guid uuid) => uuid != UUidRegraUtilizadaNaDistribuicao;
        public bool RegraNaoFoiCadastrada(Guid uuid) => !_criteriosCadastrados.Contains(uuid);
        public bool RegraContemCriterios(Guid uuid) => !_semCriterios.Contains(uuid);
        public bool RegraSemVagaDistribuida(int id) => !_vagasComDistribuicao.Contains(id);
        public bool OrgaoJulgadorInvalidoParaUnidadeInformada(Guid uuid) => !_orgaoJulgadorInvalido.Contains(uuid);

        public IQueryable<RegraDistribuicao> FiltrarDescricaoCadastrada(IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
            => from regraCadastrada in regrasCadastradas
                where regraCadastrada.Id != regraInformada.Id
                where regraCadastrada.Descricao.ToLower().Equals(regraInformada.Descricao.ToLower())
                select regraCadastrada;

        public IQueryable<RegraDistribuicao> FiltrarRegrasJaCadastradas(IQueryable<RegraDistribuicao> regrasCadastradas,
            RegraDistribuicao regraInformada)
            => regrasCadastradas
                .Where(x => x.Id != regraInformada.Id)
                .FiltrarRegraAssuntoJaCadastrado(regraInformada)
                .FiltrarRegraClasseJaCadastrado(regraInformada)
                .FiltrarRegraTarjaJaCadastrado(regraInformada)
                .FiltrarRegraUnidadeJaCadastrado(regraInformada)
                .FiltrarRegraOrgaoJaCadastrado(regraInformada)
                .FiltrarEspecialidadeJaCadastrado(regraInformada)
                .FiltrarAreaJaCadastrado(regraInformada);
                

        public IQueryable<RegraDistribuicao> ObterRegrasAtivasCompativeis(IQueryable<RegraDistribuicao> regras, ProcessoDocument processo )
            => from regra in regras                   
                   where
                    regra.Ativo && regra.VinculoVagas.Any() && ( 
                                regra.Assuntos.Any(a => a.IdAssunto == processo.IdAssunto) ||
                                regra.Classes.Any(c=> c.IdClasse == processo.IdClasse) ||
                                regra.Especialidades.Any(e=>e.IdEspecialidade == processo.IdEspecialidade) ||
                                regra.OrgaosJulgadores.Any(o => o.IdOrigem == processo.IdOrigem.GetValueOrDefault() || o.IdUnidade == processo.IdUnidade.GetValueOrDefault() || o.IdOrgaoJulgador == processo.IdOrgaoJulgador.GetValueOrDefault()) ||
                                regra.Area == processo.Area || regra.Tarjas.Select(x =>x.IdTarja).All(l =>
                                    processo.IdTarja.Contains(l)))
                   
                   select regra;

        public IQueryable<VinculoVagaRegraDistribuicao> FiltrarVagasVinculadas(
            IQueryable<VinculoVagaRegraDistribuicao> vinculosVagaRegra, RegraDistribuicao regraInformada)
            =>  from vinculo in vinculosVagaRegra
                    where vinculo.Vaga.Distribuicoes > 0
                    where vinculo.IdRegraDistribuicao == regraInformada.Id
                    select vinculo;

        public bool ExistingCriteria(List<RegraDistribuicao> regrasCadastradas, RegraDistribuicao input)
        {
            foreach (var regraCadastrado in regrasCadastradas)
            {
                if (input.Unidades.Select(u => new {u.IdUnidade, u.IdOrigem}).SequenceEqual(regraCadastrado.Unidades.Select(u => new {u.IdUnidade, u.IdOrigem}))
                    && input.Classes.Select(u => new {u.IdClasse}).SequenceEqual(regraCadastrado.Classes.Select(u => new {u.IdClasse}))
                    && input.Assuntos.Select(u => new {u.IdAssunto}).SequenceEqual(regraCadastrado.Assuntos.Select(u => new {u.IdAssunto}))
                    && input.Tarjas.Select(u => new {u.IdTarja}).SequenceEqual(regraCadastrado.Tarjas.Select(u => new {u.IdTarja}))
                    && input.OrgaosJulgadores.Select(u => new {u.IdOrgaoJulgador, u.IdUnidade, u.IdOrigem}).SequenceEqual(regraCadastrado.OrgaosJulgadores.Select(u => new {u.IdOrgaoJulgador, u.IdUnidade, u.IdOrigem}))
                    && input.Area == regraCadastrado.Area
                    && input.Especialidades.Select(u => new {u.IdEspecialidade}).SequenceEqual(regraCadastrado.Especialidades.Select(u => new {u.IdEspecialidade})))
                    return true;
            }
            return false;
        }
       
    }
}