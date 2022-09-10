using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Utilities;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos.Distribuicoes.Factories;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Parametros;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.ValueObjects;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Cadastros;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.ResolveExtensions.Distribuicoes;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.DistribuicaoProcessos.Extensions
{
    public static class DistribuicaoProcessoSorteioExtension
    {
        public static Task<IQueryable<Vaga>> RetornaVagasVinculadas(this IQueryable<VinculoVagaRegraDistribuicao> vinculoVagaRegra, RegraDistribuicao regraDistribuicao)
            => Task.FromResult(vinculoVagaRegra.Where(x => x.IdRegraDistribuicao == regraDistribuicao.Id)
                .Select(p => p.Vaga));

        public static Task<IQueryable<Vaga>> RetornaVagasVinculadasSemImpedimento(this IQueryable<Vaga> vagasVinculadas, IEnumerable<ImpedimentoProcesso> impedimentos)
            => Task.FromResult(vagasVinculadas.Where(x => !impedimentos.Select(p => p.IdVaga).Contains(x.Id)));

        public static Task<Vaga> ExecutaProcessoSorteioRandom(this IQueryable<Vaga> vagasSelecionadasParaSorteio)
        {
            var guid = Guid.NewGuid();
            return Task.FromResult(vagasSelecionadasParaSorteio.OrderBy(_ => guid).Take(vagasSelecionadasParaSorteio.Count())
                .FirstOrDefault());
        }
        public static IDistribuicaoProcessoQueryService DistribuicaoProcessoQueryService(this IGraphBuilderResolve resolve)
            => resolve.Provider.GetRequiredService<IDistribuicaoProcessoQueryService>();

    }
}