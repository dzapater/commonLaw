using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.ImpedimentoProcessos.Scenarios
{
    public class UpdateImpedimentoProcessoInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ProcessoObrigatorio();
            yield return ImpedimentoObrigatorio();
            yield return VagaObrigatoria();
            yield return MotivoObrigatorio();
            yield return ImpedimentoJaCadastrado();
        }

        private object[] ProcessoObrigatorio()
        {
            var data = ImpedimentoProcessoFaker.Entidade.Generate();
            data.IdProcesso = string.Empty;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] ImpedimentoObrigatorio()
        {
            var data = ImpedimentoProcessoFaker.Entidade.Generate();
            data.IdImpedimento = default;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] VagaObrigatoria()
        {
            var data = ImpedimentoProcessoFaker.Entidade.Generate();
            data.IdVaga = default;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] MotivoObrigatorio()
        {
            var data = ImpedimentoProcessoFaker.Entidade.Generate();
            data.Motivo = string.Empty;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }
        
        private object[] ImpedimentoJaCadastrado()
        {
            var data = ImpedimentoProcessoFaker.Entidade.Generate();
            data.IdImpedimento = ImpedimentoProcessoFixture.EntidadeCriada.IdImpedimento;
            data.IdVaga = ImpedimentoProcessoFixture.Vaga2.Id;
            data.IdProcesso = ImpedimentoProcessoFixture.EntidadeAtualizada.IdProcesso;
            data.Motivo = "teste";
            return new object[] {data, DomainResources.ImpedimentoJaCadastrado};
        }
    }
}