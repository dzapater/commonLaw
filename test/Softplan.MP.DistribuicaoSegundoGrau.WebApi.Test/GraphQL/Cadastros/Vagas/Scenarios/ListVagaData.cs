using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas.Scenarios
{
    public class ListVagaData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return ListDataBySituacaoDesativada();
            yield return ListVagasExcetoEscopoGlobal();
            yield return ListVagasExcetoEscopoLocal();
            yield return ListVagasVinculadasComEscopoGlobal();
            yield return ListVagasVinculadasComEscopoLocal();
            yield return ListVagasComRegraVinculada();
            yield return ListDataInOrder();            
            yield return ListDataByDescricao();
            yield return ListDataAreaByBusca();
            yield return ListDataByPermiteReuPreso();
            yield return ListDataByConsiderarConfiguracoesPrevencao();
            yield return ListDataByPermiteDistribuicaoMesmaVaga();
            yield return ListDataByIdArea_Criminal();
            yield return ListDataByIdArea_Civel();
            yield return ListDataByIdArea_Ambas();
            yield return ListDataByOrgao();
            yield return ListDataByProcurador();
            yield return ListDataByAtivos();
            yield return ListDataBySituacaoPedente();
            yield return ListDataBySituacaoAtiva();
            
            yield return ListDataByMultiplosFiltros();
            yield return ListDataByMultiplosFiltrosComDescricao();
            yield return ListDataByMultiplosFiltrosBooleans();
            yield return ListDataByExistePedente();
            yield return ListaSomenteVagasSemVinculoComRegraGlobal();
            yield return ListaVagasComESemVinculoComRegraGlobalQuandoFiltroFalse();
            yield return ListaVagasComESemVinculoComRegraGlobalQuandoFiltroNull();
        }
         
        private object[] ListDataInOrder()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
                items.OrderByDescending(x => x.DataAtualizacao)
                    .ThenBy(x => x.Descricao)
                    .Should().BeEquivalentTo(items, opt
                        => opt.WithStrictOrdering());

            return new object[] {assert};
        }

        private object[] ListDataByAtivos()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.EstaAtiva).Should().BeTrue();
            };

            string filter = "ativos: true";
            return new object[] {assert, filter};
        }

        private object[] ListDataByDescricao()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Descricao.Contains(VagaFixture.VagaCriada.Descricao, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            };

            string filter = $"busca: \"{VagaFixture.VagaCriada.Descricao}\"";
            return new object[] {assert, filter};
        }


        private object[] ListDataAreaByBusca()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.Any(x => x.Area == VagaFixture.VagaCriada.Area).Should().BeTrue();
            };

            var filter = $"busca: \"{VagaFixture.VagaCriada.Area}\"";
            return new object[] {assert, filter};
        }

        private object[] ListVagasComRegraVinculada()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, fixture) =>
            {
                var vinculosVagas = fixture.DbContext.Set<VinculoVagaRegraDistribuicao>().AsNoTracking()
                    .Select(x => x.IdVaga).Distinct().ToArray();

                var idsVagas = items.Select(x => x.Id).ToArray();

                items.Should().NotBeEmpty();
                items.Should().HaveCount(vinculosVagas.Length);
                idsVagas.Should().BeEquivalentTo(vinculosVagas);
            };
                
            string filter = "vinculadas: true";
            return new object[] {assert, filter};
        }
        
        private object[] ListVagasVinculadasComEscopoLocal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                var idsVagas = items.Select(x => x.Id).ToArray();
                idsVagas.Should().NotContain(VagaFixture.VagaEscopoGlobal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaEscopoLocal.Id);
                idsVagas.Should().NotContain(VagaFixture.VagaAtiva.Id);
            };
            string filter = $"vinculadas: true escopo_equilibrio: {EscopoEquilibrio.Local}";
            return new object[] {assert, filter};
        }
        
        private object[] ListVagasVinculadasComEscopoGlobal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                var idsVagas = items.Select(x => x.Id).ToArray();
                idsVagas.Should().NotContain(VagaFixture.VagaEscopoLocal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaEscopoGlobal.Id);
                idsVagas.Should().NotContain(VagaFixture.VagaAtiva.Id);
            };
            string filter = $"vinculadas: true escopo_equilibrio: {EscopoEquilibrio.Global}";
            return new object[] {assert, filter};
        }
        
        private object[] ListVagasExcetoEscopoLocal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                var idsVagas = items.Select(x => x.Id).ToArray();
                idsVagas.Should().NotContain(VagaFixture.VagaEscopoLocal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaEscopoGlobal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaAtiva.Id);
            };
            string filter = $"escopo_equilibrio: {EscopoEquilibrio.Global}";
            return new object[] { assert, filter };
        }
        
        private object[] ListVagasExcetoEscopoGlobal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                var idsVagas = items.Select(x => x.Id).ToArray();
                idsVagas.Should().NotContain(VagaFixture.VagaEscopoGlobal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaEscopoLocal.Id);
                idsVagas.Should().Contain(VagaFixture.VagaAtiva.Id);
            };
            string filter = $"escopo_equilibrio: {EscopoEquilibrio.Local}";
            return new object[] { assert, filter };
        }

        private object[] ListDataByPermiteReuPreso()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.PermiteReuPreso).Should().BeTrue();
            };

            string filter = "permite_reu_preso: true";
            return new object[] { assert, filter };
        }

        private object[] ListDataByPermiteDistribuicaoMesmaVaga()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.PermiteDistribuicaoMesmaVaga).Should().BeTrue();
            };

            string filter = "permite_distribuicao: true";
            return new object[] { assert, filter };
        }

        private object[] ListDataByConsiderarConfiguracoesPrevencao()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.ConsiderarConfiguracoesPrevencao).Should().BeTrue();
            };

            string filter = "considerar_configuracoes: true";
            return new object[] { assert, filter };
        }

        private object[] ListDataByIdArea_Criminal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == VagaFixture.VagaAreaCriminal.Area || x.Area == Area.Ambas).Should().BeTrue();
            };

            string filter = $"id_area: \"{VagaFixture.VagaAreaCriminal.Area}\"";
            return new object[] { assert, filter };
        }
        
        private object[] ListDataByIdArea_Civel()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == VagaFixture.VagaAreaCivel.Area || x.Area == Area.Ambas).Should().BeTrue();
            };

            var filter = $"id_area: \"{VagaFixture.VagaAreaCivel.Area}\"";
            return new object[] { assert, filter };
        }
        
        private object[] ListDataByIdArea_Ambas()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == Area.Criminal || x.Area == Area.Ambas || x.Area == Area.Civel).Should().BeTrue();
            };

            var filter = $"id_area: \"{Area.Ambas}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataByOrgao()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, fixture) =>
            {           
                items.Should().NotBeEmpty();
                items.All(x => x.Orgao.Id == 0).Should().BeTrue();
            };

            string filter = "id_orgao: 0";
            return new object[] { assert, filter };
        }

        private object[] ListDataByProcurador()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.ProcuradorTitular.Id.Contains(VagaFixture.VagaCriada.ProcuradorTitular.Id, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            };

            string filter = $"id_procurador_titular: \"{VagaFixture.VagaCriada.ProcuradorTitular.Id}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataBySituacaoAtiva()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Situacao == Situacao.Ativa).Should().BeTrue();
                items.Select(x => x.Id).Should().Contain(VagaFixture.VagaSituacaoAtiva.Id);
            };

            string filter = $"situacao: \"{Situacao.Ativa}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataBySituacaoPedente()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Situacao == Situacao.Pendente).Should().BeTrue();
            };

            string filter = $"situacao: \"{Situacao.Pendente}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataBySituacaoDesativada()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Situacao == Situacao.Desativada).Should().BeTrue();
            };

            string filter = $"situacao: \"{Situacao.Desativada}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataByMultiplosFiltros()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == VagaFixture.VagaCriada.Area && x.Orgao.Id == 0 && x.ProcuradorTitular.Id == VagaFixture.VagaCriada.ProcuradorTitular.Id).Should().BeTrue();
            };

            string filter = $"id_area: \"{VagaFixture.VagaCriada.Area}\" id_orgao: {0} id_procurador_titular: \"{VagaFixture.VagaCriada.ProcuradorTitular.Id}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataByMultiplosFiltrosComDescricao()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == VagaFixture.VagaCriada.Area && x.Orgao.Id == 0 && x.ProcuradorTitular.Id == VagaFixture.VagaCriada.ProcuradorTitular.Id && x.Descricao.Contains(VagaFixture.VagaCriada.Descricao, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            };

            string filter = $"id_area: \"{VagaFixture.VagaCriada.Area}\" id_orgao: {0} id_procurador_titular: \"{VagaFixture.VagaCriada.ProcuradorTitular.Id}\" busca: \"{VagaFixture.VagaCriada.Descricao}\"";
            return new object[] { assert, filter };
        }

        private object[] ListDataByMultiplosFiltrosBooleans()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.ConsiderarConfiguracoesPrevencao && x.PermiteReuPreso == false && x.PermiteDistribuicaoMesmaVaga).Should().BeTrue();
            };

            string filter = $"considerar_configuracoes: true permite_reu_preso: false permite_distribuicao: true";
            return new object[] { assert, filter };
        }

        private object[] ListDataByExistePedente()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.ExisteVagaPendente).Should().BeTrue();
            };

            string filter = $"id_procurador_titular: \"{VagaFixture.VagaCriada.ProcuradorTitular.Id}\"";
            return new object[] { assert, filter };
        }
        
        private object[] ListaSomenteVagasSemVinculoComRegraGlobal()
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, fixture) =>
            {
                var vagaGlobalIds = fixture.DbContext.Set<Vaga>().AsNoTracking()
                    .Include(x => x.RegrasVinculadas)
                    .ThenInclude(x => x.RegraDistribuicao)
                    .Where(x => x.RegrasVinculadas.Any(r => r.RegraDistribuicao.EscopoEquilibrio.Equals(EscopoEquilibrio.Global)))
                    .Select(x => x.Id).ToList();
                
                items.Should().NotBeEmpty();
                items.All(x => !x.PossuiVinculoRegraGlobal).Should().BeTrue();
                items.Select(x => x.Id).Should().NotContain(vagaGlobalIds);
            };

            var filter = "escopo_equilibrio_local_ou_indefinido: true";
            return new object[] { assert, filter };
        }

        private object[] ListaVagasComESemVinculoComRegraGlobalQuandoFiltroFalse()
            => ListaVagasComESemVinculoComRegraGlobal("false");

        private object[] ListaVagasComESemVinculoComRegraGlobalQuandoFiltroNull()
            => ListaVagasComESemVinculoComRegraGlobal("null");
        
        private object[] ListaVagasComESemVinculoComRegraGlobal(string filterValue)
        {
            Action<ICollection<VagaReadModel>, VagaFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => !x.PossuiVinculoRegraGlobal).Should().BeFalse();
            };

            var filter = $"escopo_equilibrio_local_ou_indefinido: {filterValue}";
            return new object[] { assert, filter };
        }
    }
}