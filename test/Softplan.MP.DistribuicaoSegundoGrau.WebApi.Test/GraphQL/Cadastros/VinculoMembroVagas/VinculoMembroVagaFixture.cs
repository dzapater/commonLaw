using System;
using Softplan.Common.Test.AspNetCore.Fixtures;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.DataFakers;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaFixture : TestFixtureBase<TestStartup, ApplicationSajDsgDbContext>
    {
        public static readonly VinculoMembroVaga EntidadeCriada;
        public static readonly VinculoMembroVaga EntidadeAtualizada;
        public static readonly VinculoMembroVaga EntidadeRemovida;
        public static readonly VinculoMembroVaga EntidadeComCriteriosCadastrados;
        public static readonly VinculoMembroVaga EntidadeAtualizadaVinculoVencido;
        public static readonly VinculoMembroVaga EntidadeInvalida;
        public static readonly VinculoMembroVaga EntidadeInvalidaSemDataFinal;
        public static readonly Vaga VagaAtiva;
        public static readonly Vaga Vaga;
        public static readonly Vaga VagaRemovida;
        public static readonly Vaga VagaAtualizada;
        public static readonly Vaga VagaInvalida;
        public static readonly Vaga VagaVinculoVencido;
        public static readonly Vaga VagaInvalidaDataFinalNula;

        static VinculoMembroVagaFixture()
        {
            VagaInvalidaDataFinalNula = VagaFaker.Entidade.Generate();
            VagaVinculoVencido = VagaFaker.Entidade.Generate();
            VagaInvalida = VagaFaker.Entidade.Generate();
            VagaAtualizada = VagaFaker.Entidade.Generate();
            VagaAtiva = VagaFaker.Entidade.Generate();
            VagaRemovida = VagaFaker.Entidade.Generate();
            EntidadeCriada = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeCriada.DataInicial = new DateTimeOffset(new DateTime(2021, 1, 1));
            EntidadeCriada.DataFinal = null;
            Vaga = VagaFaker.Entidade.Generate();
            EntidadeAtualizada = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeAtualizadaVinculoVencido = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeRemovida = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeComCriteriosCadastrados = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeInvalida = VinculoMembroVagaFaker.Entidade.Generate();
            EntidadeInvalidaSemDataFinal = VinculoMembroVagaFaker.Entidade.Generate();
        }
        public VinculoMembroVagaFixture()
        {
            DbContext.Add(Vaga);
            VagaAtiva.EstaAtiva = true;
            DbContext.Add(VagaAtiva);
            DbContext.Add(VagaRemovida);
            DbContext.Add(VagaAtualizada);
            DbContext.Add(VagaInvalida);
            DbContext.Add(VagaVinculoVencido);
            DbContext.Add(VagaInvalidaDataFinalNula);
            DbContext.SaveChanges();
            EntidadeCriada.IdVaga = VagaAtiva.Id;
            DbContext.Add(EntidadeCriada);
            EntidadeAtualizada.IdVaga = VagaAtualizada.Id;
            DbContext.Add(EntidadeAtualizada);
            EntidadeAtualizadaVinculoVencido.IdVaga = VagaVinculoVencido.Id;
            EntidadeAtualizadaVinculoVencido.DataFinal = DateTimeOffset.Now.AddDays(-1);
            DbContext.Add(EntidadeAtualizadaVinculoVencido);
            EntidadeInvalida.IdVaga = VagaInvalida.Id;
            DbContext.Add(EntidadeInvalida);
            EntidadeInvalidaSemDataFinal.IdVaga = VagaInvalidaDataFinalNula.Id;
            EntidadeInvalidaSemDataFinal.Vaga = VagaInvalidaDataFinalNula;
            EntidadeInvalidaSemDataFinal.DataFinal = null;
            DbContext.Add(EntidadeInvalidaSemDataFinal);
            EntidadeRemovida.Vaga = VagaRemovida;
            EntidadeRemovida.IdVaga = VagaRemovida.Id;
            EntidadeRemovida.Metadata.Uuid = VinculoMembroVagaService.UUidMembroVagaUtilizada;
            DbContext.Add(EntidadeRemovida);
            EntidadeComCriteriosCadastrados.Vaga = Vaga;
            EntidadeComCriteriosCadastrados.IdVaga = Vaga.Id;
            DbContext.Add(EntidadeComCriteriosCadastrados);
            DbContext.SaveChanges();
        }
    }
}