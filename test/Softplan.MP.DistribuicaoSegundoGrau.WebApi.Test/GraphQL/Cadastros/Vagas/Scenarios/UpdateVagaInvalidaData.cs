using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas.Scenarios
{
    public class UpdateVagaInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return DescricaoObrigatoria();
            yield return VagaJaCadastrada();
            yield return TamanhoDescricaoMenorQueTres();
        }

        private object[] DescricaoObrigatoria()
        {
            var data = VagaFaker.Entidade.Generate();
            data.Id = VagaFixture.VagaJaCadastrada.Id;
            data.Descricao = string.Empty;
            return new object[] {data, DomainResources.DescricaoMinimumLenght};
        }

        private object[] TamanhoDescricaoMenorQueTres()
        {
            var data = VagaFaker.Entidade.Generate();
            data.Id = VagaFixture.VagaJaCadastrada.Id;
            data.Descricao = "ab";
            return new object[] {data, DomainResources.DescricaoMinimumLenght};
        }

        private object[] VagaJaCadastrada()
        {
            var data = VagaFaker.Entidade.Generate();
            data.Id = VagaFixture.VagaAtiva.Id;
            data.Descricao = VagaFixture.VagaJaCadastrada.Descricao;
            return new object[] {data, DomainResources.VagaJaCadastrada};
        }
    }
}