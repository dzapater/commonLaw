using System.Linq;
using Bogus;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicaoFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly RegraDistribuicao RegraCriada;
        public static readonly RegraDistribuicao RegraAtualizada;
        public static readonly RegraDistribuicao RegraRemovida;
        public static readonly RegraDistribuicao RegraJaDistribuida;
        public static readonly RegraDistribuicao RegraAtiva;
        public static readonly RegraDistribuicao RegraPendente;
        public static readonly RegraDistribuicao RegraDesativada;
        public static readonly RegraDistribuicao RegraComCriteriosCadastrados;

        static RegraDistribuicaoFixture()
        {
            RegraCriada = RegraDistribuicaoFaker.Entidade.Generate();
            RegraAtualizada = RegraDistribuicaoFaker.Entidade.Generate();
            RegraRemovida = RegraDistribuicaoFaker.Entidade.Generate();
            RegraAtiva = RegraDistribuicaoFaker.Entidade.Generate();
            RegraPendente = RegraDistribuicaoFaker.Entidade.Generate();
            RegraDesativada = RegraDistribuicaoFaker.Entidade.Generate();
            RegraJaDistribuida = RegraDistribuicaoFaker.Entidade.Generate();
            RegraComCriteriosCadastrados = RegraDistribuicaoFaker.Entidade.Generate();
        }

        public RegraDistribuicaoFixture()
        {
            RegraCriada.Classes.First().Descricao = "Classe Teste"; 
            RegraCriada.Assuntos.First().Descricao = "Assunto Teste"; 
            RegraCriada.Especialidades.First().Descricao = "Especialidade Teste"; 
            RegraCriada.Tarjas.First().Descricao = "Tarja Teste"; 
            RegraCriada.OrgaosJulgadores.First().Descricao = "Orgao Julgador Teste"; 
            RegraCriada.Unidades.First().Descricao = "Unidade Teste"; 
            DbContext.Add(RegraCriada);

            DbContext.Add(RegraAtualizada);

            DbContext.Add(RegraRemovida);

            RegraJaDistribuida.Metadata.Uuid = RegraDistribuicaoService.UUidRegraUtilizadaNaDistribuicao;
            DbContext.Add(RegraJaDistribuida);

            RegraAtiva.Ativo = true;
            DbContext.Add(RegraAtiva);

            RegraPendente.Ativo = true;
            RegraPendente.VinculoVagas.Clear();
            DbContext.Add(RegraPendente);

            RegraDesativada.Ativo = false;
            DbContext.Add(RegraDesativada);

            RegraComCriteriosCadastrados.Assuntos = new[] {new CriterioAssunto {IdAssunto = Faker.GlobalUniqueIndex}};
            RegraComCriteriosCadastrados.Classes = new[] {new CriterioClasse {IdClasse = Faker.GlobalUniqueIndex}};
            RegraComCriteriosCadastrados.Tarjas = new[] {new CriterioTarja {IdTarja = Faker.GlobalUniqueIndex}};
            RegraComCriteriosCadastrados.Unidades = new[] {new CriterioUnidade {IdUnidade = Faker.GlobalUniqueIndex, IdOrigem = 2}};
            RegraComCriteriosCadastrados.OrgaosJulgadores = new[] {new CriterioOrgaoJulgador {IdOrgaoJulgador = Faker.GlobalUniqueIndex, IdOrigem = 2}};
            DbContext.Add(RegraComCriteriosCadastrados);
            
            DbContext.SaveChanges();
        }
    }
}