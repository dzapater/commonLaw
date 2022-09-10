using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.AnaliseProcessos.Scenarios
{
    public class AnalisarProcessoPorPrevencaoInvalidData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ProcessoObrigatorio();
            yield return TipoDistribuicaoObrigatorio();
            yield return MotivoObrigatorioPorPrevencao();
            yield return VagaObrigatoriaPorPrevenca();
            yield return MotivoMenorPorPrevencao();
            yield return MotivoVazioPorPrevencao();
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

        private object[] MotivoObrigatorioPorPrevencao()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.TipoDistribuicao = TipoDistribuicao.Prevencao;
            data.Motivo = null;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }
        
        private object[] MotivoMenorPorPrevencao()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.TipoDistribuicao = TipoDistribuicao.Prevencao;
            data.Motivo = "ab";
            return new object[] {data, DomainResources.MotivoMinimumLenght};
        }
        
        private object[] MotivoVazioPorPrevencao()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.TipoDistribuicao = TipoDistribuicao.Prevencao;
            data.Motivo = string.Empty;
            return new object[] {data, DomainResources.MotivoMinimumLenght};
        }

        private object[] VagaObrigatoriaPorPrevenca()
        {
            var data = AnaliseProcessoFaker.Entidade.Generate();
            data.TipoDistribuicao = TipoDistribuicao.Prevencao;
            data.IdVaga = default;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }
    }
}