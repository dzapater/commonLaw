using System;
using System.Collections.Generic;
using System.Linq;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoService : IDomainService
    {
        private readonly ISet<Guid> _informacoesVinculadas = new HashSet<Guid>();
        private readonly ISet<Guid> _regrasGlobaisVinculadas = new HashSet<Guid>();
        private readonly ISet<Guid> _compensacaoInvalida = new HashSet<Guid>();
        private readonly ISet<Guid> _motivoInvalido = new HashSet<Guid>();
        private readonly ISet<Guid> _regraInvalida = new HashSet<Guid>();
        

        public void NotificarInformacoesJaVinculadas(Guid uuid) => _informacoesVinculadas.Add(uuid);
        public void NotificarRegraGlobalJaVinculadas(Guid uuid) => _regrasGlobaisVinculadas.Add(uuid);
        public void NotificarCompensacaoInvalida(Guid uuid) => _compensacaoInvalida.Add(uuid);
        public void NotificarMotivoInvalido(Guid uuid) => _motivoInvalido.Add(uuid);
        public void NotificarRegraInvalida(Guid uuid) => _regraInvalida.Add(uuid);
        public bool InformacoesJaVinculadas(Guid uuid) => _informacoesVinculadas.Contains(uuid);
        public bool RegraGlobalJaVinculadas(Guid uuid) => _regrasGlobaisVinculadas.Contains(uuid);
        public bool CompensacaoInvalida(Guid uuid) => !_compensacaoInvalida.Contains(uuid);
        public bool MotivoInvalido(Guid uuid) => !_motivoInvalido.Contains(uuid);
        public bool RegraInvalida(Guid uuid) => !_regraInvalida.Contains(uuid);
        
        public IQueryable<VinculoVagaRegraDistribuicao> FiltrarInformacoesJaVinculadas(IQueryable<VinculoVagaRegraDistribuicao> queryable, VinculoVagaRegraDistribuicao entidade)
            => from item in queryable
               where item.IdVaga == entidade.IdVaga
               where item.IdRegraDistribuicao == entidade.IdRegraDistribuicao
               select item;

        public IQueryable<RegraDistribuicao> FiltrarRegrasGlobaisJaVinculadas(IQueryable<RegraDistribuicao> queryable, IEnumerable<int> regrasVinculadas)
            => from regra in queryable
               where regra.EscopoEquilibrio == EscopoEquilibrio.Global
               where regrasVinculadas.Contains(regra.Id)
               select regra;

        public bool FiltrarRegraGlobal(RegraDistribuicao regraDistribuicao) => regraDistribuicao.EscopoEquilibrio == EscopoEquilibrio.Global;

        public IQueryable<Vaga> FiltrarVagasVinculadasPorIdRegra(IQueryable<VinculoVagaRegraDistribuicao> queryable,
            int idRegraDistribuicao)
            => queryable.Where(x => x.IdRegraDistribuicao == idRegraDistribuicao)
                .Select(p => p.Vaga);
        
        public List<Vaga> ValidaCompensacao(List<Vaga> vagasCadastradas, int maxDistribuicao)
        =>(from vagaCad in vagasCadastradas
                where maxDistribuicao < vagaCad.Distribuicoes + vagaCad.Compensacao
                select vagaCad).ToList();
        
        public IQueryable<Vaga> FiltrarVagasCadastradasPorIds(IQueryable<Vaga> vagas,
            Compensacao input)
            => vagas
                .Where(x => input.Vagas.Select(p => p.Id).Contains(x.Id));
    }
}
