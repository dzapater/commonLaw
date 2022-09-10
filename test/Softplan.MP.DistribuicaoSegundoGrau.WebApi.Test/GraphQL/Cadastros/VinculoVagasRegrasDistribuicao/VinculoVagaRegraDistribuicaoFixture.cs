using System.Collections.Generic;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly VinculoVagaRegraDistribuicao EntidadeCriada;
        public static readonly VinculoVagaRegraDistribuicao EntidadeRemovida;
        public static readonly VinculoVagaRegraDistribuicao Entidade2;
        public static readonly VinculoVagaRegraDistribuicao Entidade3;
        public static readonly VinculoVagaRegraDistribuicao EntidadeGlobal;
        public static readonly VinculoVagaRegraDistribuicao EntidadeTeste;
        public static readonly Vaga VagaCriacao;
        public static readonly Vaga VagaAtiva;
        public static readonly Vaga Vaga2;
        public static readonly Vaga Vaga3;
        public static readonly Vaga Vaga4;
        public static readonly Vaga Vaga5;
        public static readonly Vaga VagaGlobal;
        public static readonly RegraDistribuicao RegraCriacao;
        public static readonly RegraDistribuicao RegraAtiva;
        public static readonly RegraDistribuicao Regra2;
        public static readonly RegraDistribuicao Regra3;
        public static readonly RegraDistribuicao Regra4;
        public static readonly RegraDistribuicao Regra5;
        public static readonly RegraDistribuicao RegraGlobal1;
        public static readonly RegraDistribuicao RegraGlobal2;
        public static readonly VagaCompensacao VagaCompensar;
        public static readonly Vaga VagaIgualarDistribuicao1;
        public static readonly Vaga VagaIgualarDistribuicao2;
        public static readonly RegraDistribuicao RegraIgualarDistribuicao;
        public static readonly VinculoVagaRegraDistribuicao VinculoIgualarDistribuicao1;
        public static readonly VinculoVagaRegraDistribuicao VinculoIgualarDistribuicao2;
        public static readonly List<CompensacaoLog> CompensacaoLogCollection;
        public static readonly RegraDistribuicao RegraRegistraCompensacao;
        public static readonly Vaga VagaRegistraCompensacao;
        public static readonly Vaga VagaRegistraCompensacaoMaxDist;
        public static readonly VinculoVagaRegraDistribuicao VinculoRegistraCompensacao;
        public static readonly VinculoVagaRegraDistribuicao VinculoRegistraCompensacaoMaxDist;

        static VinculoVagaRegraDistribuicaoFixture()
        {
            VagaCriacao = VagaFaker.Entidade.Generate();
            VagaAtiva = VagaFaker.Entidade.Generate();
            Vaga2 = VagaFaker.Entidade.Generate();
            Vaga3 = VagaFaker.Entidade.Generate();
            Vaga4 = VagaFaker.Entidade.Generate();
            Vaga5 = VagaFaker.Entidade.Generate();
            VagaGlobal = VagaFaker.Entidade.Generate();
            RegraCriacao = RegraDistribuicaoFaker.Entidade.Generate();
            RegraAtiva = RegraDistribuicaoFaker.Entidade.Generate();
            RegraGlobal1 = RegraDistribuicaoFaker.Entidade.Generate();
            RegraGlobal2 = RegraDistribuicaoFaker.Entidade.Generate();
            Regra2 = RegraDistribuicaoFaker.Entidade.Generate();
            Regra3 = RegraDistribuicaoFaker.Entidade.Generate();
            Regra4 = RegraDistribuicaoFaker.Entidade.Generate();
            Regra5 = RegraDistribuicaoFaker.Entidade.Generate();
            EntidadeCriada = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            EntidadeRemovida = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            Entidade2 = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            Entidade3 = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            EntidadeGlobal = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            VagaCompensar = VagaCompensacaoFaker.Entidade.Generate();
            VagaIgualarDistribuicao1 = VagaFaker.Entidade.Generate();
            VagaIgualarDistribuicao2 = VagaFaker.Entidade.Generate();
            RegraIgualarDistribuicao = RegraDistribuicaoFaker.Entidade.Generate();
            VinculoIgualarDistribuicao1 = new VinculoVagaRegraDistribuicao();
            VinculoIgualarDistribuicao2 = new VinculoVagaRegraDistribuicao();
            EntidadeTeste = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            CompensacaoLogCollection = CompensacaoLogFaker.Entidade.Generate(5);
            RegraRegistraCompensacao = RegraDistribuicaoFaker.Entidade.Generate();
            VagaRegistraCompensacao = VagaFaker.Entidade.Generate();
            VagaRegistraCompensacaoMaxDist = VagaFaker.Entidade.Generate();
            VinculoRegistraCompensacao = new VinculoVagaRegraDistribuicao();
            VinculoRegistraCompensacaoMaxDist = new VinculoVagaRegraDistribuicao();
            
        }

        public VinculoVagaRegraDistribuicaoFixture()
        {
            DbContext.Add(VagaCriacao);
            
            VagaAtiva.EstaAtiva = true;
            DbContext.Add(VagaAtiva);

            DbContext.Add(Vaga2);

            DbContext.Add(Vaga3);
            DbContext.Add(Vaga4);
            DbContext.Add(Vaga5);

            DbContext.Add(VagaGlobal);

            RegraCriacao.EscopoEquilibrio = EscopoEquilibrio.Local;
            DbContext.Add(RegraCriacao);
            
            RegraAtiva.Ativo = true;
            DbContext.Add(RegraAtiva);

            RegraGlobal1.EscopoEquilibrio = EscopoEquilibrio.Global;
            DbContext.Add(RegraGlobal1);
            
            RegraGlobal2.EscopoEquilibrio = EscopoEquilibrio.Global;
            DbContext.Add(RegraGlobal2);

            DbContext.Add(Regra2);

            DbContext.Add(Regra3);
            DbContext.Add(Regra4);
            DbContext.Add(Regra5);
            
            DbContext.Add(RegraIgualarDistribuicao);
            DbContext.Add(VagaIgualarDistribuicao1);
            VagaIgualarDistribuicao2.Distribuicoes = 30;
            DbContext.Add(VagaIgualarDistribuicao2);
            VinculoIgualarDistribuicao1.IdVaga = VagaIgualarDistribuicao1.Id;
            VinculoIgualarDistribuicao1.IdRegraDistribuicao = RegraIgualarDistribuicao.Id;
            VinculoIgualarDistribuicao1.Vaga = VagaIgualarDistribuicao1;
            VinculoIgualarDistribuicao1.RegraDistribuicao = RegraIgualarDistribuicao;
            VinculoIgualarDistribuicao2.IdVaga = VagaIgualarDistribuicao2.Id;
            VinculoIgualarDistribuicao2.IdRegraDistribuicao = RegraIgualarDistribuicao.Id;
            VinculoIgualarDistribuicao2.Vaga = VagaIgualarDistribuicao2;
            VinculoIgualarDistribuicao2.RegraDistribuicao = RegraIgualarDistribuicao;
            DbContext.Add(VinculoIgualarDistribuicao1);
            DbContext.Add(VinculoIgualarDistribuicao2);

            CompensacaoLogCollection.ForEach(x =>
            {
                x.IdVaga = VagaAtiva.Id;
                x.Vaga = VagaAtiva;
            });
            
            CompensacaoLogCollection.ForEach(x => DbContext.Add(x));
            
            VagaRegistraCompensacao.Distribuicoes = 0;
            DbContext.Add(VagaRegistraCompensacao);
            DbContext.Add(RegraRegistraCompensacao);
            VinculoRegistraCompensacao.IdVaga = VagaRegistraCompensacao.Id; 
            VinculoRegistraCompensacao.IdRegraDistribuicao = RegraRegistraCompensacao.Id; 
            VinculoRegistraCompensacao.Vaga = VagaRegistraCompensacao; 
            VinculoRegistraCompensacao.RegraDistribuicao = RegraRegistraCompensacao;
            DbContext.Add(VinculoRegistraCompensacao);
            
            VagaRegistraCompensacaoMaxDist.Distribuicoes = VagaRegistraCompensacao.Distribuicoes * 2;
            DbContext.Add(VagaRegistraCompensacaoMaxDist);
            VinculoRegistraCompensacaoMaxDist.IdVaga = VagaRegistraCompensacaoMaxDist.Id; 
            VinculoRegistraCompensacaoMaxDist.IdRegraDistribuicao = RegraRegistraCompensacao.Id; 
            VinculoRegistraCompensacaoMaxDist.Vaga = VagaRegistraCompensacaoMaxDist; 
            VinculoRegistraCompensacaoMaxDist.RegraDistribuicao = RegraRegistraCompensacao;
            DbContext.Add(VinculoRegistraCompensacaoMaxDist);
            
            DbContext.SaveChanges();

            EntidadeCriada.IdVaga = VagaAtiva.Id;
            EntidadeCriada.IdRegraDistribuicao = RegraAtiva.Id;
            DbContext.Add(EntidadeCriada);

            EntidadeRemovida.IdVaga = Vaga2.Id;
            EntidadeRemovida.IdRegraDistribuicao = Regra2.Id;
            DbContext.Add(EntidadeRemovida);

            Entidade2.IdVaga = Vaga2.Id;
            Entidade2.IdRegraDistribuicao = Regra3.Id;
            DbContext.Add(Entidade2);

            Entidade3.IdVaga = Vaga3.Id;
            Entidade3.IdRegraDistribuicao = Regra2.Id;
            DbContext.Add(Entidade3);

            EntidadeGlobal.IdRegraDistribuicao = RegraGlobal1.Id;
            EntidadeGlobal.IdVaga = VagaGlobal.Id;
            DbContext.Add(EntidadeGlobal);

            VagaCompensar.IdVaga = Vaga4.Id;
            VagaCompensar.IdRegraDistribuicao = Regra4.Id;
            DbContext.Add(VagaCompensar);

            EntidadeTeste.IdVaga = Vaga5.Id;
            EntidadeTeste.IdRegraDistribuicao = Regra5.Id;

            DbContext.SaveChanges();
        }
    }
}