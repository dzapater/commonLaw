using System.Collections;
using System.Collections.Generic;
using Softplan.MP.DistribuicaoSegundoGrau.Domain;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao.Scenarios
{
    public class CreateRegraDistribuicaoInvalidaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return DescricaoObrigatoria();
            yield return VariavelEquilibrioObrigatoria();
            yield return EscopoEquilibrioObrigatorio();
            yield return CriteriosJaCadastrados();
            yield return SemCriterios();
            yield return RegraJaCadastrada();
        }

        private object[] RegraJaCadastrada()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.Descricao = RegraDistribuicaoFixture.RegraAtiva.Descricao;
            return new object[] { data, DomainResources.DadosJaCadastrados };
        }

        private object[] DescricaoObrigatoria()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.Descricao = string.Empty;
            return new object[] {data, DomainResources.DescricaoNaoInformada};
        }

        private object[] VariavelEquilibrioObrigatoria()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.VariavelEquilibrio = VariavelEquilibrio.Indefinido;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] EscopoEquilibrioObrigatorio()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.EscopoEquilibrio = EscopoEquilibrio.Indefinido;
            return new object[] {data, DomainResources.CampoObrigatorioNaoInformado};
        }

        private object[] CriteriosJaCadastrados()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.Descricao = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Descricao;
            data.Area = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Area;
            data.Especialidades = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Especialidades;
            data.Assuntos = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Assuntos;
            data.Classes = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Classes;
            data.Tarjas = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Tarjas;
            data.Unidades = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.Unidades;
            data.OrgaosJulgadores = RegraDistribuicaoFixture.RegraComCriteriosCadastrados.OrgaosJulgadores;
            return new object[] {data, DomainResources.DadosJaCadastrados};
        }
        
        private object[] SemCriterios()
        {
            var data = RegraDistribuicaoFaker.Entidade.Generate();
            data.Descricao = "Descrição para Regra sem critérios";
            data.Area = null;
            data.TipoProcesso = null;
            data.Especialidades = new List<CriterioEspecialidade>();
            data.Assuntos = new List<CriterioAssunto>();
            data.Classes = new List<CriterioClasse>();
            data.Tarjas = new List<CriterioTarja>();
            data.Unidades = new List<CriterioUnidade>();
            data.OrgaosJulgadores = new List<CriterioOrgaoJulgador>();
            return new object[] {data, DomainResources.RegraSemCriterios};
        }
    }
}