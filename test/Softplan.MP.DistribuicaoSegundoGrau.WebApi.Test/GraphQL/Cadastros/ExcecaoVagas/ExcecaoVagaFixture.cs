using System.Threading.Tasks;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas
{
    public class ExcecaoVagaFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly ExcecaoVaga EntidadeCriada;
        public static readonly ExcecaoVaga EntidadeAtualizada;
        public static readonly ExcecaoVaga EntidadeRemovida;
        public static readonly ExcecaoVaga EntidadeComCriteriosCadastrados;

        static ExcecaoVagaFixture()
        {
            EntidadeCriada = ExcecaoVagaFaker.Entidade.Generate();
            EntidadeAtualizada = ExcecaoVagaFaker.Entidade.Generate();
            EntidadeRemovida = ExcecaoVagaFaker.Entidade.Generate();
            EntidadeComCriteriosCadastrados = ExcecaoVagaFaker.Entidade.Generate();
        }

        public ExcecaoVagaFixture()
        {
            AddEntities();
        }

        private void AddEntities()
        {
            DbContext.Add(EntidadeCriada);
            DbContext.Add(EntidadeAtualizada);
            DbContext.Add(EntidadeRemovida);
            DbContext.Add(EntidadeComCriteriosCadastrados);
            DbContext.SaveChanges();
        }
    }
}