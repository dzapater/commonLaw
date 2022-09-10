using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.ExcecaoVagas.Scenarios
{
    public class CreateExcecaoVagaInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return VagaIdObrigatoria();
            yield return CriteriosJaCadastrados();
            yield return NenhumaExcecaoCadastrada();
        }

        private object[] VagaIdObrigatoria()
        {
            var data = ExcecaoVagaFaker.Entidade.Generate();
            data.IdVaga = 0;
            return new object[] {data, DomainResources.ObrigadoInformarIdVaga};
        }


        private object[] CriteriosJaCadastrados()
        {
            var data = ExcecaoVagaFixture.EntidadeComCriteriosCadastrados;            
            return new object[] {data, DomainResources.ExcecaoJaCadastrada};
        }

        private object[] NenhumaExcecaoCadastrada()
        {
            var data = ExcecaoVagaFaker.Entidade.Generate();
            data.IdVaga = ExcecaoVagaFixture.EntidadeComCriteriosCadastrados.IdVaga;
            data.IdAssunto = null;
            return new object[] { data, DomainResources.NenhumaExcecaoCadastrada };
        }
    }
}