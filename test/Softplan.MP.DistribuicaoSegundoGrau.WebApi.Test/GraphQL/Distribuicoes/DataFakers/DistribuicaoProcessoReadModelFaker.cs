using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Google.Protobuf.WellKnownTypes;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Commands;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.Messages.Protos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers
{
        public class DistribuicaoProcessoReadModelFaker
        {
            public static readonly Faker<DistribuicaoProcessoReadModel> RequestCriarDistribuicaoProcesso =
                new Faker<DistribuicaoProcessoReadModel>()
                    .RuleFor(x => x.DistribuicaoProcesso,CriaDistribuicaoProcessoFaker( new DistribuirProcessoRequest()
                    {
                        IdProcesso = "idProcesso"
                    }))
                    .RuleFor(x => x.DistribuicaoProcessoLog, new List<DistribuicaoProcessoLog>()
                    {
                        CriaDistribuicaoProcessoFaker( new DistribuirProcessoRequest()
                        {
                            IdProcesso = "idProcesso"
                        }).Logs.FirstOrDefault()
                    });
            
            public static readonly Faker<DistribuicaoProcessoReadModel> RequestCriarDistribuicaoProcessoVagaMapeada =
                new Faker<DistribuicaoProcessoReadModel>()
                    .RuleFor(x => x.DistribuicaoProcesso,CriaDistribuicaoProcessoVagaMapeadaFaker( new DistribuirProcessoRequest()
                    {
                        IdProcesso = "idProcessoVagaMapeada"
                    }))
                    .RuleFor(x => x.DistribuicaoProcessoLog, new List<DistribuicaoProcessoLog>()
                    {
                        CriaDistribuicaoProcessoVagaMapeadaFaker( new DistribuirProcessoRequest()
                        {
                            IdProcesso = "idProcessoVagaMapeada"
                        }).Logs.FirstOrDefault()
                    });
            
            public static readonly Faker<DistribuicaoProcessoReadModel> RequestCriarDistribuicaoProcessoParaVagaJaDistribuida =
                new Faker<DistribuicaoProcessoReadModel>()
                    .RuleFor(x => x.DistribuicaoProcesso,CriaDistribuicaoProcessoParaVagaJaDistribuidaFaker( new DistribuirProcessoRequest()
                    {
                        IdProcesso = "idProcessoVagaJaDistribuida"
                    }))
                    .RuleFor(x => x.DistribuicaoProcessoLog, new List<DistribuicaoProcessoLog>()
                    {
                        CriaDistribuicaoProcessoParaVagaJaDistribuidaFaker( new DistribuirProcessoRequest()
                        {
                            IdProcesso = "idProcessoVagaJaDistribuida"
                        }).Logs.FirstOrDefault()
                    });
            
            public static readonly Faker<DistribuicaoProcessoReadModel> RequestCriarDistribuicaoProcessoParaVagaExcecao =
                new Faker<DistribuicaoProcessoReadModel>()
                    .RuleFor(x => x.DistribuicaoProcesso,CriaDistribuicaoProcessoParaVagaExcecaoFaker( new DistribuirProcessoRequest()
                    {
                        IdProcesso = "idProcessoVagaExcecao"
                    }))
                    .RuleFor(x => x.DistribuicaoProcessoLog, new List<DistribuicaoProcessoLog>()
                    {
                        CriaDistribuicaoProcessoParaVagaExcecaoFaker( new DistribuirProcessoRequest()
                        {
                            IdProcesso = "idProcessoVagaExcecao"
                        }).Logs.FirstOrDefault()
                    });

            private static DistribuicaoProcesso CriaDistribuicaoProcessoFaker(DistribuirProcessoRequest distribuicaoFaker)
            {
                distribuicaoFaker.TipoDistribuicao = TipoDistribuicao.Sorteio;
                distribuicaoFaker.IdVaga = 9999;
                distribuicaoFaker.IdProcesso = "idProcesso";
                var command = new LogarDistribuicaoProcessoCommand
                {
                    IdProcesso = distribuicaoFaker.IdProcesso,
                    Motivo = distribuicaoFaker.Motivo,
                    TipoDistribuicao = distribuicaoFaker.TipoDistribuicao,
                    IdVaga = (int)distribuicaoFaker.IdVaga,

                };
                var distribuicao = DistribuicaoProcesso.Create(command);
                distribuicao.Metadata.Uuid = command.TransactionId;
                distribuicao.Metadata.UsuarioAtualizacao = "UsuarioTeste";
                var domainEvent = MapProcessoFoiDistribuidoPorSorteio(distribuicao);
                distribuicao.AddLog(domainEvent);
                return distribuicao;
            }
            
            private static DistribuicaoProcesso CriaDistribuicaoProcessoParaVagaJaDistribuidaFaker(DistribuirProcessoRequest distribuicaoFaker)
            {
                distribuicaoFaker.TipoDistribuicao = TipoDistribuicao.Sorteio;
                distribuicaoFaker.IdVaga = 1234;
                distribuicaoFaker.IdProcesso = "idProcesso";
                var command = new LogarDistribuicaoProcessoCommand
                {
                    IdProcesso = distribuicaoFaker.IdProcesso,
                    Motivo = distribuicaoFaker.Motivo,
                    TipoDistribuicao = distribuicaoFaker.TipoDistribuicao,
                    IdVaga = (int)distribuicaoFaker.IdVaga,

                };
                var distribuicao = DistribuicaoProcesso.Create(command);
                distribuicao.Metadata.Uuid = command.TransactionId;
                distribuicao.Metadata.UsuarioAtualizacao = "UsuarioTeste";
                var domainEvent = MapProcessoFoiDistribuidoPorSorteio(distribuicao);
                distribuicao.AddLog(domainEvent);
                return distribuicao;
            }
            
            private static DistribuicaoProcesso CriaDistribuicaoProcessoParaVagaExcecaoFaker(DistribuirProcessoRequest distribuicaoFaker)
            {
                distribuicaoFaker.TipoDistribuicao = TipoDistribuicao.Sorteio;
                distribuicaoFaker.IdVaga = 4321;
                distribuicaoFaker.IdProcesso = "idProcessoExcecao";
                var command = new LogarDistribuicaoProcessoCommand
                {
                    IdProcesso = distribuicaoFaker.IdProcesso,
                    Motivo = distribuicaoFaker.Motivo,
                    TipoDistribuicao = distribuicaoFaker.TipoDistribuicao,
                    IdVaga = (int)distribuicaoFaker.IdVaga,

                };
                var distribuicao = DistribuicaoProcesso.Create(command);
                distribuicao.Metadata.Uuid = command.TransactionId;
                distribuicao.Metadata.UsuarioAtualizacao = "UsuarioTeste";
                var domainEvent = MapProcessoFoiDistribuidoPorSorteio(distribuicao);
                distribuicao.AddLog(domainEvent);
                return distribuicao;
            }
            
            private static DistribuicaoProcesso CriaDistribuicaoProcessoVagaMapeadaFaker(DistribuirProcessoRequest distribuicaoFaker)
            {
                distribuicaoFaker.TipoDistribuicao = TipoDistribuicao.Sorteio;
                distribuicaoFaker.IdVaga = 1;
                distribuicaoFaker.IdRegraDistribuicao = 1;
                distribuicaoFaker.IdProcesso = "idProcesso";
                var command = new LogarDistribuicaoProcessoCommand
                {
                    IdProcesso = distribuicaoFaker.IdProcesso,
                    Motivo = distribuicaoFaker.Motivo,
                    TipoDistribuicao = distribuicaoFaker.TipoDistribuicao,
                    IdVaga = (int)distribuicaoFaker.IdVaga,
                    IdRegraDistribuicao = distribuicaoFaker.IdRegraDistribuicao

                };
                var distribuicao = DistribuicaoProcesso.Create(command);
                distribuicao.Metadata.Uuid = command.TransactionId;
                distribuicao.Metadata.UsuarioAtualizacao = "UsuarioTeste";
                var domainEvent = MapVagaFoiSelecionadaParaDistribuicao(command);
                distribuicao.AddLog(domainEvent);
                return distribuicao;
            }
            
            public static ProcessoFoiDistribuidoPorSorteio MapProcessoFoiDistribuidoPorSorteio(DistribuicaoProcesso distribuicaoProcesso)
                => new ProcessoFoiDistribuidoPorSorteio
                {
                    IdProcesso = distribuicaoProcesso.IdProcesso, Usuario = distribuicaoProcesso.Metadata.UsuarioAtualizacao,
                    DataOcorrencia = Timestamp.FromDateTimeOffset(distribuicaoProcesso.Metadata.DataAtualizacao)
                };
            private static VagaFoiSelecionadaParaDistribuicao MapVagaFoiSelecionadaParaDistribuicao(LogarDistribuicaoProcessoCommand command)
                => new VagaFoiSelecionadaParaDistribuicao
                {
                    IdVaga = command.IdVaga,
                    IdRegraDistribuicao = command.IdRegraDistribuicao,
                    IdProcesso = command.IdProcesso,
                    Volumes = command.Volumes
                };
        }
}