using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas
{
    public class MotivoMembroVagaFixture : TestFixtureBase<TestStartup, ApplicationDbContext>
    {
        public static readonly MotivoMembroVagaReadModel Entidade;
        public static readonly MotivoMembroVagaReadModel EntidadeAtiva;
        public static readonly MotivoMembroVagaReadModel MotivoMembroVagaAtiva;
        static readonly MotivoMembroVagaReadModel MotivoMembroVagaAtualizada;
        public static readonly MotivoMembroVagaReadModel MotivoMembroVagaRemovido;
        public static readonly MotivoMembroVagaReadModel MotivoMembroVaga;
        
        static MotivoMembroVagaFixture()
        {
            Entidade = MotivoMembroVagaFaker.Entidade.Generate();
            EntidadeAtiva = MotivoMembroVagaFaker.Entidade.Generate();
            MotivoMembroVaga = MotivoMembroVagaFaker.Entidade.Generate();
            MotivoMembroVagaAtualizada = MotivoMembroVagaFaker.Entidade.Generate();
            MotivoMembroVagaAtiva = MotivoMembroVagaFaker.Entidade.Generate();
            MotivoMembroVagaRemovido = MotivoMembroVagaFaker.Entidade.Generate();
        }

        public MotivoMembroVagaFixture()
        {
            EntidadeAtiva.Ativo = "A";
            DbContext.Add(EntidadeAtiva);
            DbContext.Add(Entidade);
            DbContext.Add(EntidadeAtiva);
            
            DbContext.Add(MotivoMembroVaga);
            MotivoMembroVagaAtiva.Ativo = "A";
            DbContext.Add(MotivoMembroVagaAtiva);
            
            DbContext.Add(MotivoMembroVagaAtiva);
            DbContext.Add(MotivoMembroVagaRemovido);
            DbContext.Add(MotivoMembroVagaAtualizada);
            
            DbContext.SaveChanges();
        }
    }
}