using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos.Scenarios
{
    public class AnalisarProcessoPorSorteioInvalidData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ProcessoObrigatorio();
            yield return TipoDistribuicaoObrigatorio();
        }

        private object[] ProcessoObrigatorio()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.IdProcesso = string.Empty;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] TipoDistribuicaoObrigatorio()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.TipoDistribuicao = TipoDistribuicao.Indefinida;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }
    }
}