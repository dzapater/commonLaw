using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Documents;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.ValueObjects;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcessoService : IDomainService
    {       

        public IQueryable<Vaga> FiltrarVagasDistribuicaoMesmaVaga(IQueryable<DistribuicaoProcesso> distribuicoes,
                                                                    IQueryable<AnaliseProcesso> analises,
                                                                    IQueryable<Vaga> vagasSemImpedimento)
        {
            var dateTimeNow = DateTimeOffset.Now.Date;

            return from vaga in vagasSemImpedimento
                   join analise in analises
                       on vaga.Id equals analise.IdVaga
                   join distribuicao in distribuicoes
                       on analise.IdProcesso equals distribuicao.IdProcesso
                   where analise.TipoDistribuicao.Equals(TipoDistribuicao.Sorteio)
                   && distribuicao.Metadata.DataAtualizacao >= dateTimeNow
                   && !vaga.PermiteDistribuicaoMesmaVaga
                   select vaga;
        }

        public IQueryable<DistribuicaoVagaDocument> BuscarDadosDistribuicao(IQueryable<VinculoVagaRegraDistribuicao> vinculos,
            int regraId, IQueryable<int> vagaIds, Expression<Func<VinculoVagaRegraDistribuicao, DistribuicaoVagaDocument>> expression)
            => (from vinculo in vinculos
                where vagaIds.Contains(vinculo.IdVaga)
                      && vinculo.IdRegraDistribuicao == regraId
                select vinculo).Select(expression);

        public IQueryable<Vaga> FiltrarVagasComExcecao(IQueryable<ExcecaoVaga> excecaoVaga, 
                                                         IQueryable<Vaga> vagasSemImpedimento, 
                                                         ProcessoDocument processoDocument)
        {
            return from vaga in vagasSemImpedimento
                   join excecao in excecaoVaga
                       on vaga.Id equals excecao.IdVaga
                   where 
                    (excecao.IdAssunto == null || excecao.IdAssunto == processoDocument.IdAssunto) && 
                    (excecao.IdClasse == null || excecao.IdClasse == processoDocument.IdClasse) &&
                    (excecao.IdEspecialidade == null || excecao.IdEspecialidade == processoDocument.IdEspecialidade) &&
                    (excecao.IdOrgaoJulgador == null || excecao.IdOrgaoJulgador == processoDocument.IdOrgaoJulgador) &&
                    (excecao.IdOrigem == null || excecao.IdOrigem == processoDocument.IdOrigem) &&
                    (excecao.IdUnidade == null || excecao.IdUnidade == processoDocument.IdUnidade)
                   select vaga;
        }
        
        public async Task<IOrderedEnumerable<KeyValuePair<RegraDistribuicao, int>>> ObtemRegraDistribuicaoMaisEspecificaProcesso(List<RegraDistribuicao> regraDistribuicoes,
            ProcessoDocument processo) => new RegraDistribuicaoMaisEspecifica(regraDistribuicoes, processo).RegraMaisEspecifica;

        public IQueryable<DistribuicaoVagaDocument> BuscarIdVagasARemoverDesvioInvalido(IQueryable<DistribuicaoVagaDocument> queryable,
            int? desvio)
        {
            var desvioInt = desvio ?? 3;
            if (queryable.All(x => x.VariavelEquilibrio.Equals(VariavelEquilibrio.Volume)))
            {
                var distribuicaoTotalMinima = queryable.Min(x => x.DistribuicaoPorVolume + x.CompensacaoPorVolume);
                queryable = queryable.Where(x =>
                    x.DistribuicaoPorVolume + x.CompensacaoPorVolume - distribuicaoTotalMinima >= desvioInt);
                return queryable;
            }
            else
            {
                var distribuicaoTotalMinima = queryable.Min(x => x.Distribuicao + x.Compensacao);
                queryable = queryable.Where(x => x.Distribuicao + x.Compensacao - distribuicaoTotalMinima >= desvioInt);
                return queryable;
            }
        }
    }
}