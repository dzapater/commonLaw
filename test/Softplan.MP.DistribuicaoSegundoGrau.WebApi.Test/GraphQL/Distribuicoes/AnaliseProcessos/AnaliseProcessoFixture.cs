using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos
{
    public class AnaliseProcessoFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly AnaliseProcesso EntidadeCriadaPorPrevencao;
        public static readonly AnaliseProcesso EntidadeAtualizadaPorPrevencao;
        public static readonly AnaliseProcesso EntidadeCriadaPorSorteio;
        public static readonly AnaliseProcesso EntidadeAtualizadaPorSorteio;

        static AnaliseProcessoFixture()
        {
            EntidadeCriadaPorPrevencao = AnaliseProcessoFaker.Entidade.Generate();
            EntidadeAtualizadaPorPrevencao = AnaliseProcessoFaker.Entidade.Generate();
            EntidadeCriadaPorSorteio = AnaliseProcessoFaker.Entidade.Generate();
            EntidadeAtualizadaPorSorteio = AnaliseProcessoFaker.Entidade.Generate();
        }

        public AnaliseProcessoFixture()
        {
            EntidadeCriadaPorPrevencao.TipoDistribuicao = TipoDistribuicao.Prevencao;
            EntidadeCriadaPorPrevencao.AreaAtuacao = new AreaAtuacao {Id = 1};
            DbContext.Add(EntidadeCriadaPorPrevencao);

            EntidadeAtualizadaPorPrevencao.TipoDistribuicao = TipoDistribuicao.Prevencao;
            DbContext.Add(EntidadeAtualizadaPorPrevencao);

            EntidadeCriadaPorSorteio.TipoDistribuicao = TipoDistribuicao.Sorteio;
            EntidadeCriadaPorPrevencao.AreaAtuacao = new AreaAtuacao {Id = 1};
            DbContext.Add(EntidadeCriadaPorSorteio);

            EntidadeAtualizadaPorSorteio.TipoDistribuicao = TipoDistribuicao.Sorteio;
            DbContext.Add(EntidadeAtualizadaPorSorteio);

            DbContext.SaveChanges();
        }
    }
}