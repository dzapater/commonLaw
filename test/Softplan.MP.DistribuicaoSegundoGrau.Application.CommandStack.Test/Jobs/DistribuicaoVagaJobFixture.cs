using Softplan.Common.Test.AspNetCore;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Fakers;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Jobs
{
    public class DistribuicaoVagaJobFixture: TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static DistribuicaoVagaJob VagaJob;

        static DistribuicaoVagaJobFixture()
        {
            VagaJob = DistribuicaoVagaJobFaker.CriarDistribuicaoVagaJobFaker.Generate();
        }

        public DistribuicaoVagaJobFixture()
        {
            AddEntities();
        }

        private void AddEntities()
        {
            DbContext.Add(VagaJob);
            DbContext.SaveChanges();
        }
    }
}