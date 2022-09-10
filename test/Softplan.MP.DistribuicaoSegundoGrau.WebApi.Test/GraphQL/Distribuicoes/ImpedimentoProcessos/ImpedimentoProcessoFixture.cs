using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos
{
    public class ImpedimentoProcessoFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly ImpedimentoProcesso EntidadeCriada;
        public static readonly ImpedimentoProcesso EntidadeAtualizada;
        public static readonly ImpedimentoProcesso EntidadeRemovida;
        public static readonly ImpedimentoProcesso EntidadeDistribuicaoProcesso;
        public static readonly Vaga VagaCriada;
        public static readonly Vaga Vaga1;
        public static readonly Vaga Vaga2;
        public static readonly Vaga Vaga3;
        public static readonly Vaga Vaga4;

        static ImpedimentoProcessoFixture()
        {
            VagaCriada = VagaFaker.Entidade.Generate();
            Vaga1 = VagaFaker.Entidade.Generate();
            Vaga2 = VagaFaker.Entidade.Generate();
            Vaga3 = VagaFaker.Entidade.Generate();
            Vaga4 = VagaFaker.Entidade.Generate();
            EntidadeCriada = ImpedimentoProcessoFaker.Entidade.Generate();
            EntidadeAtualizada = ImpedimentoProcessoFaker.Entidade.Generate();
            EntidadeRemovida = ImpedimentoProcessoFaker.Entidade.Generate();
            EntidadeDistribuicaoProcesso = ImpedimentoProcessoFaker.Entidade.Generate();
        }

        public ImpedimentoProcessoFixture()
        {
            DbContext.Add(VagaCriada);
            DbContext.Add(Vaga1);
            DbContext.Add(Vaga2);
            DbContext.Add(Vaga3);
            DbContext.Add(Vaga4);

            DbContext.SaveChanges();

            EntidadeCriada.IdVaga = Vaga1.Id;
            DbContext.Add(EntidadeCriada);

            EntidadeAtualizada.IdVaga = Vaga2.Id;
            DbContext.Add(EntidadeAtualizada);

            EntidadeRemovida.IdVaga = Vaga3.Id;
            DbContext.Add(EntidadeRemovida);
            
            EntidadeDistribuicaoProcesso.IdVaga = Vaga4.Id;
            EntidadeDistribuicaoProcesso.IdProcesso = "idProcesso";
            DbContext.Add(EntidadeDistribuicaoProcesso);

            DbContext.SaveChanges();
        }
    }
}