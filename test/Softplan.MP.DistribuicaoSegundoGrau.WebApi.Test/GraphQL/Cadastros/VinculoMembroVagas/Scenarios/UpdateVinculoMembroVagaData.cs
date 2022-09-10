using System.Collections;
using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas.Scenarios
{
    public class UpdateVinculoMembroVagaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public IEnumerator<object[]> GetEnumerator()
        {
            VinculoMembroVagaFixture.EntidadeAtualizada.DataInicial = VinculoMembroVagaFixture.EntidadeAtualizada.DataInicial.AddYears(3);
            VinculoMembroVagaFixture.EntidadeAtualizada.DataFinal = VinculoMembroVagaFixture.EntidadeAtualizada.DataFinal?.AddYears(3);
            yield return new object[] {VinculoMembroVagaFixture.EntidadeAtualizada};
        }
    }
}