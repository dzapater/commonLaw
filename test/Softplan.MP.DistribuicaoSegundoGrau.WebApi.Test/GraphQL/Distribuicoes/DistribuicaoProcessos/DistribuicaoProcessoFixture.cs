using System;
using System.Collections.Generic;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.AnaliseProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ImpedimentoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DistribuicaoProcessos
{
    public class DistribuicaoProcessoFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static Vaga VagaImpedimento;
        public static ImpedimentoProcesso ImpedimentoProcesso;
        public static Vaga VagaDistribuicao;
        public static Vaga VagaDistribuicaoFluxoSorteioOuPrevencao;
        public static Vaga VagaDistribuicaoFluxoSorteioOuPrevencao2;
        public static Vaga VagaImpedimento1;
        public static Vaga VagaImpedimento2;
        public static RegraDistribuicao RegraDistribuicaoImpedimento;        
        public static RegraDistribuicao RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao;        
        public static VinculoVagaRegraDistribuicao VinculoVagaDistribuicaoFluxoSorteioOuPrevencao;
        public static VinculoVagaRegraDistribuicao VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2;        
        public static VinculoVagaRegraDistribuicao VinculoVagaDistribuicaoImpedimento1;   
        public static VinculoVagaRegraDistribuicao VinculoVagaDistribuicaoImpedimento2;
        public static AnaliseProcesso AnaliseProcessoFluxoSorteioOuPrevencao;
        public static AnaliseProcesso AnaliseProcessoFluxoSorteioOuPrevencao2;
        public static DistribuicaoProcessoReadModel DistribuicaoReadModelFaker;
        public static ImpedimentoProcesso Impedimento;

        public static AnaliseProcesso AnaliseProcessoFluxoComExcecao;

        static DistribuicaoProcessoFixture()
        {
            ImpedimentoProcesso = ImpedimentoProcessoFaker.Entidade.Generate();
            DistribuicaoReadModelFaker =
                DistribuicaoProcessoReadModelFaker.RequestCriarDistribuicaoProcesso.Generate();
            VagaImpedimento = VagaFaker.Entidade.Generate();
            VagaDistribuicao = VagaFaker.Entidade.Generate();

            VagaDistribuicaoFluxoSorteioOuPrevencao = VagaFaker.Entidade.Generate();
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            AnaliseProcessoFluxoSorteioOuPrevencao = AnaliseProcessoFaker.Entidade.Generate();            
            RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao = RegraDistribuicaoFaker.Entidade.Generate();            

            VagaDistribuicaoFluxoSorteioOuPrevencao2 = VagaFaker.Entidade.Generate();
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2 = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            AnaliseProcessoFluxoSorteioOuPrevencao2 = AnaliseProcessoFaker.Entidade.Generate();     
            
            VagaImpedimento1 = VagaFaker.Entidade.Generate();
            VagaImpedimento2 = VagaFaker.Entidade.Generate();
            RegraDistribuicaoImpedimento = RegraDistribuicaoFaker.Entidade.Generate();
            VinculoVagaDistribuicaoImpedimento1 = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            VinculoVagaDistribuicaoImpedimento2 = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();

            Impedimento = ImpedimentoProcessoFaker.Entidade.Generate();

            AnaliseProcessoFluxoComExcecao = AnaliseProcessoFaker.Entidade.Generate();
        }

        public DistribuicaoProcessoFixture()
        {
            AddFirstMock();
            DistribuicaoComDistribuicaoPrevencaoPreviaSemExcecao();
            DistribuicaoComVagaImpedida();
            ProcessoVagasRemovidasDistribuicaoMesmaVaga();
            ProcessoVagasComExcecao();
            VagasRemovidasParaDistribuicaoCriterioDesvio();
        }

        private void AddFirstMock()
        {
            DbContext.Add(VagaImpedimento);
            DbContext.Add(VagaDistribuicao);
            DbContext.SaveChanges();

            ImpedimentoProcesso.IdVaga = VagaImpedimento.Id;
            ImpedimentoProcesso.Vaga = VagaImpedimento;
            DbContext.Add(ImpedimentoProcesso);
            DbContext.SaveChanges();

            VagaDistribuicaoFluxoSorteioOuPrevencao.Id = VagaDistribuicaoFluxoSorteioOuPrevencao.Id;
            DbContext.Add(VagaDistribuicaoFluxoSorteioOuPrevencao);
            DbContext.SaveChanges();
            
            AnaliseProcessoFluxoSorteioOuPrevencao.IdVaga = VagaDistribuicaoFluxoSorteioOuPrevencao.Id;
            AnaliseProcessoFluxoSorteioOuPrevencao.TipoDistribuicao = TipoDistribuicao.Sorteio;
            DbContext.Add(AnaliseProcessoFluxoSorteioOuPrevencao);
            DbContext.SaveChanges();
            
            RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao.Id = 1284;
            RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao.Area = Area.Ambas;
            RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao.Ativo = true;
            DbContext.Add(RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao);
            DbContext.SaveChanges();
            
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao.IdVaga = VagaDistribuicaoFluxoSorteioOuPrevencao.Id;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao.Vaga = VagaDistribuicaoFluxoSorteioOuPrevencao;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao.IdRegraDistribuicao = 1284;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao.RegraDistribuicao =
                RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao;
            DbContext.Add(VinculoVagaDistribuicaoFluxoSorteioOuPrevencao);
            DbContext.SaveChanges();
        }

        private void DistribuicaoComVagaImpedida()
        {
            RegraDistribuicaoImpedimento.EscopoEquilibrio = EscopoEquilibrio.Global;
            RegraDistribuicaoImpedimento.VariavelEquilibrio = VariavelEquilibrio.Processo;
            RegraDistribuicaoImpedimento.Assuntos = new List<CriterioAssunto>
            {
                new CriterioAssunto{IdAssunto = 4, Id = RegraDistribuicaoImpedimento.Id}
            };
            DbContext.Add(RegraDistribuicaoImpedimento);
            DbContext.SaveChanges();
            DbContext.Add(VagaImpedimento1);
            DbContext.Add(VagaImpedimento2);
            DbContext.SaveChanges();
            
            VinculoVagaDistribuicaoImpedimento1.IdVaga = VagaImpedimento1.Id;
            VinculoVagaDistribuicaoImpedimento1.IdRegraDistribuicao = RegraDistribuicaoImpedimento.Id;
            VinculoVagaDistribuicaoImpedimento1.Vaga = VagaImpedimento1;
            VinculoVagaDistribuicaoImpedimento1.RegraDistribuicao = RegraDistribuicaoImpedimento;
            DbContext.Add(VinculoVagaDistribuicaoImpedimento1);
            DbContext.SaveChanges();
            
            VinculoVagaDistribuicaoImpedimento2.IdVaga = VagaImpedimento2.Id;
            VinculoVagaDistribuicaoImpedimento2.IdRegraDistribuicao = RegraDistribuicaoImpedimento.Id;
            VinculoVagaDistribuicaoImpedimento2.Vaga = VagaImpedimento2;
            VinculoVagaDistribuicaoImpedimento2.RegraDistribuicao = RegraDistribuicaoImpedimento;
            DbContext.Add(VinculoVagaDistribuicaoImpedimento2);
            DbContext.SaveChanges();
            
            Impedimento.IdProcesso = "PROCESSO_VAGA_IMPEDIDA";
            Impedimento.IdVaga = VagaImpedimento2.Id;
            Impedimento.Vaga = VagaImpedimento2;
            DbContext.Add(Impedimento);
            DbContext.SaveChanges();
        }

        private void DistribuicaoComDistribuicaoPrevencaoPreviaSemExcecao()
        {
            VagaDistribuicaoFluxoSorteioOuPrevencao2.Id = VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            DbContext.Add(VagaDistribuicaoFluxoSorteioOuPrevencao2);
            DbContext.SaveChanges();

            AnaliseProcessoFluxoSorteioOuPrevencao2.IdVaga = VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            AnaliseProcessoFluxoSorteioOuPrevencao2.TipoDistribuicao = TipoDistribuicao.Prevencao;
            AnaliseProcessoFluxoSorteioOuPrevencao2.AreaAtuacao = new AreaAtuacao { Id = 2 };
            DbContext.Add(AnaliseProcessoFluxoSorteioOuPrevencao2);
            DbContext.SaveChanges();

            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2.IdVaga = VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2.Vaga = VagaDistribuicaoFluxoSorteioOuPrevencao2;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2.IdRegraDistribuicao = 1284;
            VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2.RegraDistribuicao =
                RegraDistribuicaoFluxoDistribuicaoFluxoSorteioOuPrevencao;
            DbContext.Add(VinculoVagaDistribuicaoFluxoSorteioOuPrevencao2);
            DbContext.SaveChanges();

            var distroPrevencao = DistribuicaoProcessoFaker.RequestCriarDistribuicaoProcesso.Generate();
            distroPrevencao.TipoDistribuicao = TipoDistribuicao.Prevencao;
            distroPrevencao.IdVaga = VagaDistribuicaoFluxoSorteioOuPrevencao2.Id;
            distroPrevencao.IdProcesso = AnaliseProcessoFluxoSorteioOuPrevencao2.IdProcesso;
            var command = new LogarDistribuicaoProcessoCommand
            {
                IdProcesso = distroPrevencao.IdProcesso,
                Motivo = distroPrevencao.Motivo,
                TipoDistribuicao = distroPrevencao.TipoDistribuicao,
                IdVaga = (int)distroPrevencao.IdVaga,
                TransactionId = Guid.NewGuid()

        };
            var distribuicao = DistribuicaoProcesso.Create(command);
            distribuicao.Metadata.UsuarioAtualizacao = "UsuarioTeste";
            distribuicao.Metadata.Uuid = command.TransactionId;
            var domainEvent = DistribuicaoProcessoReadModelFaker.MapProcessoFoiDistribuidoPorSorteio(distribuicao);
            distribuicao.AddLog(domainEvent);
            DbContext.Add(distribuicao);
            DbContext.SaveChanges();
        }

        private void ProcessoVagasRemovidasDistribuicaoMesmaVaga()
        {
            var distribuicao = DistribuicaoProcessoReadModelFaker.RequestCriarDistribuicaoProcessoParaVagaJaDistribuida.Generate();
            var regra = RegraDistribuicaoFaker.Entidade.Generate();
            regra.Id = 1286;
            regra.Assuntos = new List<CriterioAssunto>()
            {
                new CriterioAssunto()
                {
                    Id = regra.Id,
                    IdAssunto = 2,
                    Descricao = "AssuntoDescDefault"
                }
            };
            regra.Especialidades = new List<CriterioEspecialidade>()
            {
                new CriterioEspecialidade()
                {
                    Id = regra.Id,
                    IdEspecialidade = 2,
                    Descricao = "EspecDescDefault"
                }
            };
            regra.OrgaosJulgadores = new List<CriterioOrgaoJulgador>()
            {
                new CriterioOrgaoJulgador()
                {
                    Id = regra.Id,
                    IdOrigem = 10,
                    IdUnidade = 10,
                    IdOrgaoJulgador = 10,
                    Descricao = "OrgaoJulgadorDefault"
                }
            };
            regra.Area = Area.Ambas;
            regra.Ativo = true;

            var analise = AnaliseProcessoFaker.Entidade.Generate();
            analise.AreaAtuacao = new AreaAtuacao() {Id = 99, Nome = "Teste"};
            analise.IdVaga = distribuicao.DistribuicaoProcesso.IdVaga;
            analise.IdProcesso = distribuicao.DistribuicaoProcesso.IdProcesso;
            analise.TipoDistribuicao = TipoDistribuicao.Sorteio;

            var vaga = VagaFaker.Entidade.Generate();
            vaga.PermiteDistribuicaoMesmaVaga = false;
            vaga.Id = (int) distribuicao.DistribuicaoProcesso.IdVaga;
            vaga.Descricao = "VAGA_PROCESSO_DISTRIBUICAO_MESMA_VAGA";

            var vinculo = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
            vinculo.Vaga = vaga;
            vinculo.IdVaga = (int) distribuicao.DistribuicaoProcesso.IdVaga;
            vinculo.RegraDistribuicao = regra;
            vinculo.IdRegraDistribuicao = 1286;

            DbContext.Add(vaga);
            DbContext.Add(regra);
            DbContext.SaveChanges();
            DbContext.Add(distribuicao.DistribuicaoProcesso);
            DbContext.Add(analise);
            DbContext.Add(vinculo);
            DbContext.SaveChanges();
        }

        private void ProcessoVagasComExcecao()
        {
                var regra = RegraDistribuicaoFaker.Entidade.Generate();
                regra.Id = 4321;
                regra.Assuntos = new List<CriterioAssunto>()
                {
                    new CriterioAssunto()
                    {
                        Id = regra.Id,
                        IdAssunto = 2,
                        Descricao = "AssuntoDescDefault"
                    }
                };
                regra.Especialidades = new List<CriterioEspecialidade>()
                {
                    new CriterioEspecialidade()
                    {
                        Id = regra.Id,
                        IdEspecialidade = 2,
                        Descricao = "EspecDescDefault"
                    }
                };
                regra.OrgaosJulgadores = new List<CriterioOrgaoJulgador>()
                {
                    new CriterioOrgaoJulgador()
                    {
                        Id = regra.Id,
                        IdOrigem = 10,
                        IdUnidade = 10,
                        IdOrgaoJulgador = 10,
                        Descricao = "OrgaoJulgadorDefault"
                    }
                };
                regra.Area = Area.Ambas;
                regra.Ativo = true;

                var vaga = VagaFaker.Entidade.Generate();
                vaga.PermiteDistribuicaoMesmaVaga = false;
                vaga.Id = 4321;
                vaga.Descricao = "VAGA_PROCESSO_EXCECAO_VAGA";
                
                var analise = AnaliseProcessoFaker.Entidade.Generate();
                analise.AreaAtuacao = new AreaAtuacao() {Id = 99, Nome = "Teste"};
                analise.IdVaga = vaga.Id;
                analise.IdProcesso = "idProcessoExcecao";
                analise.TipoDistribuicao = TipoDistribuicao.Sorteio;

                var vinculo = VinculoVagaRegraDistribuicaoFaker.Entidade.Generate();
                vinculo.Vaga = vaga;
                vinculo.IdVaga = 4321;
                vinculo.RegraDistribuicao = regra;
                vinculo.IdRegraDistribuicao = 4321;

                DbContext.Add(vaga);
                DbContext.Add(regra);
                DbContext.SaveChanges();
                DbContext.Add(analise);
                DbContext.Add(vinculo);
                DbContext.SaveChanges();
                
                var entidadeArrange = ExcecaoVagaFaker.EntidadeNullable.Generate();

                entidadeArrange.IdVaga = vaga.Id;
                DbContext.Add(entidadeArrange);
                DbContext.SaveChanges();
        }

        private void VagasRemovidasParaDistribuicaoCriterioDesvio()
        {
            var regra = RegraDistribuicaoFaker.Entidade.Generate();
            regra.Id = 5555;
            regra.Area = Area.Ambas;
            regra.Ativo = true;
            regra.VariavelEquilibrio = VariavelEquilibrio.Volume;
            regra.EscopoEquilibrio = EscopoEquilibrio.Global;
            regra.Assuntos = new List<CriterioAssunto>()
            {
                new CriterioAssunto()
                {
                    Id = regra.Id,
                    IdAssunto = 2,
                    Descricao = "AssuntoDescDefault"
                }
            };
            regra.Especialidades = new List<CriterioEspecialidade>()
            {
                new CriterioEspecialidade()
                {
                    Id = regra.Id,
                    IdEspecialidade = 2,
                    Descricao = "EspecDescDefault"
                }
            };
            regra.OrgaosJulgadores = new List<CriterioOrgaoJulgador>()
            {
                new CriterioOrgaoJulgador()
                {
                    Id = regra.Id,
                    IdOrigem = 10,
                    IdUnidade = 10,
                    IdOrgaoJulgador = 10,
                    Descricao = "OrgaoJulgadorDefault"
                }
            };

            DbContext.Add(regra);

            var vaga = VagaFaker.Entidade.Generate();
            vaga.PermiteDistribuicaoMesmaVaga = true;
            vaga.Descricao = "VAGA_PROCESSO_DESVIO_1";
            vaga.DistribuicaoPorVolume = 10000;
            vaga.CompensacaoPorVolume = 10000;

            var vinculo = new VinculoVagaRegraDistribuicao
            {
                IdVaga = vaga.Id,
                IdRegraDistribuicao = regra.Id,
                Vaga = vaga,
                RegraDistribuicao = regra
            };

            var vaga2 = VagaFaker.Entidade.Generate();
            vaga2.PermiteDistribuicaoMesmaVaga = true;
            vaga2.Descricao = "VAGA_PROCESSO_DESVIO_2";
            vaga2.DistribuicaoPorVolume = 0;
            vaga2.CompensacaoPorVolume = 0;

            var vinculo2 = new VinculoVagaRegraDistribuicao
            {
                IdVaga = vaga2.Id,
                IdRegraDistribuicao = regra.Id,
                Vaga = vaga2,
                RegraDistribuicao = regra
            };

            DbContext.AddRange(new List<VinculoVagaRegraDistribuicao> { vinculo, vinculo2 });

            DbContext.SaveChanges();
        }
    }
}