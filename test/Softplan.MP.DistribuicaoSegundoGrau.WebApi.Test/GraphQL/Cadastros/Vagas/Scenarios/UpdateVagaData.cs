using System.Collections;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas.Scenarios
{
    public class UpdateVagaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return UpdateVaga();
        }
        
        private object[] UpdateVaga()
        {
            var data = VagaFaker.Entidade.Generate();
            data.Id = VagaFixture.VagaCriada.Id;
            data.Descricao = new Faker().Company.CompanyName().ClampLength(max: 120);
            data.Area = new Faker().PickRandom(new[] {Area.Ambas, Area.Civel, Area.Criminal});
            data.Motivo = new Faker().Lorem.Sentence();
            data.ProcuradorTitular = new ProcuradorTitular{Id =  new Faker().Company.CompanyName().ClampLength(max: 20)};
            data.IdInstalacao = Faker.GlobalUniqueIndex;
            data.Distribuicoes = Faker.GlobalUniqueIndex;
            data.Compensacao = Faker.GlobalUniqueIndex;
            data.Orgao.IdTipoOrgao = Faker.GlobalUniqueIndex;
            data.ConsiderarConfiguracoesPrevencao = new Faker().PickRandom(true, false);
            data.EstaAtiva = new Faker().PickRandom(true, false);
            data.PermiteReuPreso = new Faker().PickRandom(true, false);
            data.PermiteDistribuicaoMesmaVaga = new Faker().PickRandom(true, false);
            return new object[] { data };
        } 
    }
}