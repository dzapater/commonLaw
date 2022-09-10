using System;
using Softplan.Common.Core.Extensions;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Area = Softplan.MP.Utils.SharedKernel.Area;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.Vagas
{
    public class VagaFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly Vaga VagaSituacaoAtiva;
        public static readonly Vaga VagaPermiteReuPreso;
        public static readonly Vaga VagaCriada;
        public static readonly Vaga VagaAtualizada;
        public static readonly Vaga VagaRemovida;
        public static readonly Vaga VagaJaCadastrada;
        public static readonly Vaga VagaAtiva;
        public static readonly Vaga VagaDesativada;
        public static readonly Vaga VagaAreaAmbas;
        public static readonly Vaga VagaAreaCivel;
        public static readonly Vaga VagaAreaCriminal;
        public static readonly RegraDistribuicao RegraGlobal;
        public static readonly RegraDistribuicao RegraLocal;
        public static readonly VinculoVagaRegraDistribuicao VinculoEscopoLocal;
        public static readonly VinculoVagaRegraDistribuicao VinculoEscopoGlobal;
        public static readonly VinculoMembroVaga VinculoMembroVagaDesativada;
        public static readonly Vaga VagaEscopoGlobal;
        public static readonly Vaga VagaEscopoLocal;
        public static readonly VinculoMembroVaga MembroVagaAtivo;

        static VagaFixture()
        {
            VagaCriada = VagaFaker.Entidade.Generate();
            VagaAtualizada = VagaFaker.Entidade.Generate();
            VagaRemovida = VagaFaker.Entidade.Generate();
            VagaJaCadastrada = VagaFaker.Entidade.Generate();
            VagaAtiva = VagaFaker.Entidade.Generate();
            VagaDesativada = VagaFaker.Entidade.Generate();            
            VagaEscopoGlobal = VagaFaker.Entidade.Generate();
            VagaEscopoLocal = VagaFaker.Entidade.Generate();
            RegraGlobal = RegraDistribuicaoFaker.Entidade.Generate();
            RegraLocal = RegraDistribuicaoFaker.Entidade.Generate();
            VinculoEscopoLocal = new VinculoVagaRegraDistribuicao();
            VinculoEscopoGlobal = new VinculoVagaRegraDistribuicao();
            VinculoMembroVagaDesativada = VinculoMembroVagaFaker.Entidade.Generate();
            MembroVagaAtivo = VinculoMembroVagaFaker.Entidade.Generate();
            VagaPermiteReuPreso = VagaFaker.Entidade.Generate();
            VagaSituacaoAtiva = VagaFaker.Entidade.Generate();
            VagaAreaAmbas = VagaFaker.Entidade.Generate();
            VagaAreaCivel = VagaFaker.Entidade.Generate();
            VagaAreaCriminal = VagaFaker.Entidade.Generate();
        }

        public VagaFixture()
        {
            DbContext.Add(VagaCriada);
            DbContext.Add(VagaAtualizada);
            DbContext.Add(VagaRemovida);
            DbContext.Add(VagaJaCadastrada);
            DbContext.Add(VagaEscopoGlobal);
            DbContext.Add(VagaEscopoLocal);

            RegraLocal.EscopoEquilibrio = EscopoEquilibrio.Local;
            RegraGlobal.EscopoEquilibrio = EscopoEquilibrio.Global;
            DbContext.Add(RegraLocal);
            DbContext.Add(RegraGlobal);

            VagaAtiva.EstaAtiva = true;
            VagaAtiva.ConsiderarConfiguracoesPrevencao = true;
            VagaAtiva.PermiteReuPreso = false;
            VagaAtiva.PermiteDistribuicaoMesmaVaga = true;
            
            VagaDesativada.EstaAtiva = false;
            DbContext.Add(VagaAtiva);
            DbContext.Add(VagaDesativada);

            VinculoEscopoGlobal.IdVaga = VagaEscopoGlobal.Id;
            VinculoEscopoGlobal.Vaga = VagaEscopoGlobal;
            VinculoEscopoGlobal.RegraDistribuicao = RegraGlobal;
            VinculoEscopoGlobal.IdRegraDistribuicao = RegraGlobal.Id;

            VinculoEscopoLocal.IdVaga = VagaEscopoLocal.Id;
            VinculoEscopoLocal.Vaga = VagaEscopoLocal;
            VinculoEscopoLocal.RegraDistribuicao = RegraLocal;
            VinculoEscopoLocal.IdRegraDistribuicao = RegraLocal.Id;

            DbContext.Add(VinculoEscopoLocal);
            DbContext.Add(VinculoEscopoGlobal);

            VagaAreaAmbas.Area = Domain.Valores.Area.Ambas;
            VagaAreaCivel.Area = Domain.Valores.Area.Civel;
            VagaAreaCriminal.Area = Domain.Valores.Area.Criminal;
            DbContext.Add(VagaAreaAmbas);
            DbContext.Add(VagaAreaCivel);
            DbContext.Add(VagaAreaCriminal);
            
            DbContext.SaveChanges();
            
            VinculoMembroVagaDesativada.IdVaga = VagaDesativada.Id;
            VinculoMembroVagaDesativada.IdMembro = Situacao.DesativacaoPlanejada.GetDescription();
            DbContext.Add(VinculoMembroVagaDesativada);
            
            DbContext.SaveChanges();

            PermiteReuPreso();
            VagaComSituacaoAtiva();
        }

        private void PermiteReuPreso()
        {
            VagaPermiteReuPreso.PermiteReuPreso = true;
            DbContext.Add(VagaPermiteReuPreso);
            DbContext.SaveChanges();
        }
        
        private void VagaComSituacaoAtiva()
        {
            DbContext.Add(VagaSituacaoAtiva);
            DbContext.SaveChanges();
            
            MembroVagaAtivo.IdVaga = VagaSituacaoAtiva.Id;
            MembroVagaAtivo.DataInicial = DateTimeOffset.Now;
            MembroVagaAtivo.DataFinal = null;
            DbContext.Add(MembroVagaAtivo);
            DbContext.SaveChanges();
        }
    }
}