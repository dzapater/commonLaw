using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.RegrasDistribuicao.Scenarios
{
    public class ListRegrasDistribuicaoData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
             yield return ListRegraByTipoProcesso();
             yield return ListDataInOrder();
             yield return ListDataByAtivos();
             
             yield return ListDataDescricaoByBusca();
             yield return ListDataAreaByBusca();
             yield return ListDataEscopoEquilibrioByBusca();
             yield return ListDataVariavelEquilibrioByBusca();
             yield return ListDataClasseByBusca();
             yield return ListDataAssuntoByBusca();
             yield return ListDataTarjaByBusca();
             yield return ListDataOrgaoJulgadorByBusca();
             yield return ListDataUnidadeByBusca();
             
             yield return ListRegraByDescricao();
             yield return ListRegraByArea();
             yield return ListRegraByEscopoEquilibrio();
             yield return ListRegraByVariavelEquilibrio();
             yield return ListRegraByIdClasse();
             yield return ListRegraByIdAssunto();
             yield return ListRegraByIdTarja();
             yield return ListRegraByIdOrgaoJulgador();
             yield return ListRegraByIdUnidade();
             yield return ListRegraByIdEspecialidade();
             yield return ListRegraByIdOrigem();
             yield return ListRegraBySituacaoPendente();
             yield return ListRegraBySituacaoDesativada();
             yield return ListRegraByExistePendente();
        }

        private object[] ListDataInOrder()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
                items.OrderByDescending(x => x.DataAtualizacao)
                    .ThenBy(x => x.Descricao)
                    .Should().BeEquivalentTo(items, opt
                        => opt.WithStrictOrdering());

            return new object[] {assert};
        }

        private object[] ListDataByAtivos()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Ativo).Should().BeTrue();
            };

            string filter = $"ativos: true";
            return new object[] {assert, filter};
        }

        private object[] ListDataDescricaoByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Descricao.Contains(RegraDistribuicaoFixture.RegraCriada.Descricao, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            };

            string filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByDescricao()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Descricao.Contains(RegraDistribuicaoFixture.RegraCriada.Descricao, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            };

            string filter = $"descricao: \"{RegraDistribuicaoFixture.RegraCriada.Descricao}\"";
            return new object[] {assert, filter};
        }

        private object[] ListDataAreaByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == RegraDistribuicaoFixture.RegraCriada.Area || x.Area == Area.Ambas).Should().BeTrue();
            };

            string filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Area}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByArea()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Area == RegraDistribuicaoFixture.RegraCriada.Area || x.Area == Area.Ambas).Should().BeTrue();
            };

            string filter = $"area: {RegraDistribuicaoFixture.RegraCriada.Area}";
            return new object[] {assert, filter};
        }
       
        private object[] ListRegraBySituacaoPendente()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Ativo == true && x.QuantidadeVagasVinculadasAtivas == 0).Should().BeTrue();
            };

            string filter = $"situacao: {Situacao.Pendente}";
            return new object[] { assert, filter };
        }
        
        private object[] ListRegraBySituacaoDesativada()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.Ativo == false ).Should().BeTrue();
            };

            string filter = $"situacao: {Situacao.Desativada}";
            return new object[] { assert, filter };
        }

        private object[] ListDataEscopoEquilibrioByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.EscopoEquilibrio == RegraDistribuicaoFixture.RegraCriada.EscopoEquilibrio).Should().BeTrue();
            };

            string filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.EscopoEquilibrio}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByEscopoEquilibrio()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.EscopoEquilibrio == RegraDistribuicaoFixture.RegraCriada.EscopoEquilibrio).Should().BeTrue();
            };

            string filter = $"escopo_equilibrio: {RegraDistribuicaoFixture.RegraCriada.EscopoEquilibrio}";
            return new object[] {assert, filter};
        }

        private object[] ListDataVariavelEquilibrioByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.VariavelEquilibrio == RegraDistribuicaoFixture.RegraCriada.VariavelEquilibrio).Should().BeTrue();
            };

            string filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.VariavelEquilibrio}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByVariavelEquilibrio()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.VariavelEquilibrio == RegraDistribuicaoFixture.RegraCriada.VariavelEquilibrio).Should().BeTrue();
            };

            string filter = $"variavel_equilibrio: {RegraDistribuicaoFixture.RegraCriada.VariavelEquilibrio}";
            return new object[] {assert, filter};
        }

        private object[] ListDataClasseByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var classes = GetIdsClasse(ids, fixture);

                items.Should().NotBeEmpty();
                classes.Should().NotBeEmpty();
            };

            var filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Classes.First().Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdClasse()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var classes = GetIdsClasse(ids, fixture);

                items.Should().NotBeEmpty();
                classes.All(x => x == RegraDistribuicaoFixture.RegraCriada.Classes.First().IdClasse).Should().BeTrue();
            };

            string filter = $"id_classe: {RegraDistribuicaoFixture.RegraCriada.Classes.First().IdClasse}";
            return new object[] {assert, filter};
        }

        private object[] ListDataAssuntoByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var assuntos = GetIdsAssunto(ids, fixture);

                items.Should().NotBeEmpty();
                assuntos.Should().NotBeEmpty();
            };

            var filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Assuntos.First().Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdAssunto()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var assuntos = GetIdsAssunto(ids, fixture);

                items.Should().NotBeEmpty();
                assuntos.All(x => x == RegraDistribuicaoFixture.RegraCriada.Assuntos.First().IdAssunto).Should().BeTrue();
            };

            string filter = $"id_assunto: {RegraDistribuicaoFixture.RegraCriada.Assuntos.First().IdAssunto}";
            return new object[] {assert, filter};
        }

        private object[] ListDataTarjaByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var tarjas = GetIdsTarja(ids, fixture);

                items.Should().NotBeEmpty();
                tarjas.Should().NotBeEmpty();
            };

            var filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Tarjas.First().Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdTarja()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var tarjas = GetIdsTarja(ids, fixture);

                items.Should().NotBeEmpty();
                tarjas.All(x => x == RegraDistribuicaoFixture.RegraCriada.Tarjas.First().IdTarja).Should().BeTrue();
            };

            string filter = $"id_tarja: {RegraDistribuicaoFixture.RegraCriada.Tarjas.First().IdTarja}";
            return new object[] {assert, filter};
        }

        private object[] ListDataOrgaoJulgadorByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var orgaos = GetIdsOrgaoJulgador(ids, fixture);

                items.Should().NotBeEmpty();
                orgaos.Should().NotBeEmpty();
            };

            var filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdOrgaoJulgador()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var orgaos = GetIdsOrgaoJulgador(ids, fixture);

                items.Should().NotBeEmpty();
                orgaos.All(x => x == RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrgaoJulgador).Should().BeTrue();
            };

            string filter = $"id_orgao: {RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrgaoJulgador}";
            return new object[] {assert, filter};
        }

        private object[] ListDataUnidadeByBusca()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var unidades = GetIdsUnidade(ids, fixture);

                items.Should().NotBeEmpty();
                unidades.Should().NotBeEmpty();
            };

            string filter = $"busca: \"{RegraDistribuicaoFixture.RegraCriada.Unidades.First().Descricao}\"";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdUnidade()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var unidades = GetIdsUnidade(ids, fixture);

                items.Should().NotBeEmpty();
                unidades.All(x => x == RegraDistribuicaoFixture.RegraCriada.Unidades.First().IdUnidade).Should().BeTrue();
            };

            string filter = $"id_unidade: {RegraDistribuicaoFixture.RegraCriada.Unidades.First().IdUnidade}";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByTipoProcesso()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.TipoProcesso.Equals(RegraDistribuicaoFixture.RegraCriada.TipoProcesso)).Should().BeTrue();
            };

            string filter = $"tipo_processo: {RegraDistribuicaoFixture.RegraCriada.TipoProcesso}";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdEspecialidade()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var unidades = GetIdsEspecialidade(ids, fixture);

                items.Should().NotBeEmpty();
                unidades.All(x => x == RegraDistribuicaoFixture.RegraCriada.Especialidades.First().IdEspecialidade).Should().BeTrue();
            };

            string filter = $"id_especialidade: {RegraDistribuicaoFixture.RegraCriada.Especialidades.First().IdEspecialidade}";
            return new object[] {assert, filter};
        }
        
        private object[] ListRegraByIdOrigem()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, fixture) =>
            {
                var ids = items.Select(x => x.Id).ToArray();
                var unidades = GetIdsOrigem(ids, fixture);

                items.Should().NotBeEmpty();
                unidades.All(x => x == RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrigem).Should().BeTrue();
            };

            string filter = $"id_origem: {RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrigem}";
            return new object[] {assert, filter};
        }

        private object[] ListRegraByExistePendente()
        {
            Action<ICollection<RegraDistribuicaoReadModel>, RegraDistribuicaoFixture> assert = (items, _) =>
            {
                items.Should().NotBeEmpty();
                items.All(x => x.ExisteRegraPendente == true).Should().BeTrue();
            };

            string filter = $"situacao: {Situacao.Pendente}";
            return new object[] { assert, filter };
        }

        private int[] GetIdsOrigem(int[] ids, RegraDistribuicaoFixture fixture)
            => fixture.DbContext.Set<RegraDistribuicao>()
                .AsNoTracking().Where(x => ids.Contains(x.Id))
                .SelectMany(x => x.OrgaosJulgadores.Select(c => c.IdOrigem))
                .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrigem))
                .Distinct()
                .ToArray();

        private long[] GetIdsEspecialidade(int[] ids, RegraDistribuicaoFixture fixture)
            => fixture.DbContext.Set<RegraDistribuicao>()
                .AsNoTracking().Where(x => ids.Contains(x.Id))
                .SelectMany(x => x.Especialidades.Select(c => c.IdEspecialidade))
                .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.Especialidades.First().IdEspecialidade))
                .Distinct()
                .ToArray();
        
        private long[] GetIdsUnidade(int[] ids, RegraDistribuicaoFixture fixture)
            => fixture.DbContext.Set<RegraDistribuicao>()
                .AsNoTracking().Where(x => ids.Contains(x.Id))
                .SelectMany(x => x.Unidades.Select(c => c.IdUnidade))
                .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.Unidades.First().IdUnidade))
                .Distinct()
                .ToArray();

        private long[] GetIdsClasse(int[] ids, RegraDistribuicaoFixture fixture)
        => fixture.DbContext.Set<RegraDistribuicao>()
            .AsNoTracking().Where(x => ids.Contains(x.Id))
            .SelectMany(x => x.Classes.Select(c => c.IdClasse))
            .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.Classes.First().IdClasse))
            .Distinct()
            .ToArray();
        
        private long[] GetIdsAssunto(int[] ids, RegraDistribuicaoFixture fixture)
        => fixture.DbContext.Set<RegraDistribuicao>()
            .AsNoTracking().Where(x => ids.Contains(x.Id))
            .SelectMany(x => x.Assuntos.Select(c => c.IdAssunto))
            .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.Assuntos.First().IdAssunto))
            .Distinct()
            .ToArray();
        
        private long[] GetIdsTarja(int[] ids, RegraDistribuicaoFixture fixture)
        => fixture.DbContext.Set<RegraDistribuicao>()
            .AsNoTracking().Where(x => ids.Contains(x.Id))
            .SelectMany(x => x.Tarjas.Select(c => c.IdTarja))
            .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.Tarjas.First().IdTarja))
            .Distinct()
            .ToArray();
        
        private long[] GetIdsOrgaoJulgador(int[] ids, RegraDistribuicaoFixture fixture)
        => fixture.DbContext.Set<RegraDistribuicao>()
                .AsNoTracking().Where(x => ids.Contains(x.Id))
                .SelectMany(x => x.OrgaosJulgadores.Select(c => c.IdOrgaoJulgador))
                .Where(x => x.Equals(RegraDistribuicaoFixture.RegraCriada.OrgaosJulgadores.First().IdOrgaoJulgador))
                .Distinct()
                .ToArray();
        
    }
}