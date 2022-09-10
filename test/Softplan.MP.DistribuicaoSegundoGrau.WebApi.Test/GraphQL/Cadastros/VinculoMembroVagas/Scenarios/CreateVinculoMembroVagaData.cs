using System;
using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class CreateVinculoMembroVagaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return VinculoMembroVagaDataFinalNull();
            yield return VinculoMembroVagaComDataFinalMembroAnteriorNula();
        }


        private object[] VinculoMembroVagaDataFinalNull()
        {
            var item = VinculoMembroVagaFaker.Entidade.Generate();
            item.Vaga = VinculoMembroVagaFixture.EntidadeCriada.Vaga;
            item.IdVaga = VinculoMembroVagaFixture.EntidadeCriada.IdVaga;
            item.DataInicial = DateTimeOffset.Now.Date;
            item.DataFinal = null;
            item.Observacao = "data final nula";
            return new object[] {item};
        }

        private object[] VinculoMembroVagaComDataFinalMembroAnteriorNula()
        {
            var item = VinculoMembroVagaFaker.Entidade.Generate();
            item.Vaga = VinculoMembroVagaFixture.EntidadeCriada.Vaga;
            item.IdVaga = VinculoMembroVagaFixture.EntidadeCriada.IdVaga;
            item.DataInicial = DateTimeOffset.Now.Date.AddDays(1);
            item.DataFinal = DateTimeOffset.Now.Date.AddDays(1);
            item.Observacao = "data final membro anterior nula";
            return new object[] {item};
        }
    }
}