using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Softplan.Common.EntityFrameworkCore.Abstractions.UnitOfWorks;
using Softplan.Common.Repositories.Abstractions;
using Softplan.Common.Services.Abstractions.Services;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Jobs;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoVagasRegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs.Distribuicoes;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.GraphQL.Distribuicoes.DataFakers;
using Xunit;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Test.Jobs
{
    public class DistribuicaoVagaJobApplicationServiceTest
    {
        private Mock<IUnitOfWork> _moqIUnitOfWork = new Mock<IUnitOfWork>();
        private Mock<IServiceProvider> _moqServiceProvider = new Mock<IServiceProvider>();

        private Mock<IDistribuicaoProcessoRepository> _moqIDistribuicaoProcessoRepository =
            new Mock<IDistribuicaoProcessoRepository>();
        
        private Mock<IReadRepository<DistribuicaoVagaJob>> _moqReadRepository = new Mock<IReadRepository<DistribuicaoVagaJob>>();
        private Mock<IReadRepository<RegraDistribuicao>> _moqReadRepositoryRegra = new Mock<IReadRepository<RegraDistribuicao>>();
        private Mock<IReadRepository<Vaga>> _moqReadRepositoryVaga = new Mock<IReadRepository<Vaga>>();
        private Mock<IReadRepository<VinculoVagaRegraDistribuicao>> _moqReadRepositoryVinculo = new Mock<IReadRepository<VinculoVagaRegraDistribuicao>>();
        
        private Mock<ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>> _moqCrudServiceVinculo = new Mock<ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>>();
        private Mock<ICrudService<Vaga, IdVaga>> _moqCrudServiceVaga = new Mock<ICrudService<Vaga, IdVaga>>();
        private Mock<ICrudService<DistribuicaoVagaJob, IdJob>> _moqCrudServiceJob =
            new Mock<ICrudService<DistribuicaoVagaJob, IdJob>>();

        public DistribuicaoVagaJobApplicationServiceTest(){}

        [Fact]
        public async Task Dado_Distribuicao_Quando_AgendarTratamentoVaga_Entao_JobSchedulerSucesso()
        {
            var distribuicao = DistribuicaoProcessoReadModelFaker.RequestCriarDistribuicaoProcessoVagaMapeada.Generate();
            var vagaJob = DistribuicaoVagaJobFixture.VagaJob;
            
            _moqIUnitOfWork.Setup(x => x.ExecuteAsync(It.IsAny<Func<Task>>()))
                .Returns<Func<Task>>(onExecute => onExecute());
                
            _moqReadRepository.Setup(x => 
                    x.GetFirstAsync(It.IsAny<Expression<Func<DistribuicaoVagaJob, bool>>>()))
                .Returns(Task.FromResult(vagaJob)); 
               
            List<RegraDistribuicao> regras = new List<RegraDistribuicao>(){new RegraDistribuicao(){Id = 1}};
            IQueryable<RegraDistribuicao> queryableRegras = regras.AsQueryable();
            _moqReadRepositoryRegra.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<RegraDistribuicao, bool>>>()))
                .Returns(Task.FromResult(queryableRegras));

            List<Vaga> vagas = new List<Vaga>(){new Vaga(){Id = 1}};
            IQueryable<Vaga> queryablevagas = vagas.AsQueryable();
            _moqReadRepositoryVaga.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Vaga, bool>>>()))
                .Returns(Task.FromResult(queryablevagas));
            
            List<VinculoVagaRegraDistribuicao> vinculoVagas = new List<VinculoVagaRegraDistribuicao>()
            { 
                new VinculoVagaRegraDistribuicao() {
                    Vaga = new Vaga() {Id = 1},
                    RegraDistribuicao = new RegraDistribuicao() {Id = 1},
                    IdVaga = 1,
                    IdRegraDistribuicao = 1
                }
            };
            IQueryable<VinculoVagaRegraDistribuicao> queryableVinculoVagas = vinculoVagas.AsQueryable();
            _moqReadRepositoryVinculo.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<VinculoVagaRegraDistribuicao, bool>>>()))
                .Returns(Task.FromResult(queryableVinculoVagas));

            _moqIDistribuicaoProcessoRepository.Setup(x => x.LoadLogsAsync(
                    It.IsAny<Expression<Func<DistribuicaoProcessoLog, bool>>>()))
                .Returns(Task.FromResult((distribuicao.DistribuicaoProcessoLog.ToArray())));
            
            _moqCrudServiceVaga.Setup(x => x.UpdateAsync(It.IsAny<Vaga>()))
                .Returns(Task.FromResult(vagas.FirstOrDefault()));
            _moqCrudServiceVinculo.Setup(x => x.UpdateAsync(It.IsAny<VinculoVagaRegraDistribuicao>()))
                .Returns(Task.FromResult(regras.FirstOrDefault()));
            _moqCrudServiceJob.Setup(x => x.UpdateAsync(It.IsAny<DistribuicaoVagaJob>())).Returns(Task.FromResult(vagaJob));

            _moqServiceProvider.Setup(x => x.GetService(typeof(IDistribuicaoProcessoRepository))).Returns(_moqIDistribuicaoProcessoRepository.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IReadRepository<DistribuicaoVagaJob>))).Returns(_moqReadRepository.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IReadRepository<RegraDistribuicao>))).Returns(_moqReadRepositoryRegra.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IReadRepository<Vaga>))).Returns(_moqReadRepositoryVaga.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(IReadRepository<VinculoVagaRegraDistribuicao>))).Returns(_moqReadRepositoryVinculo.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(ICrudService<VinculoVagaRegraDistribuicao, IdVinculoVagaRegraDistribuicao>))).Returns(_moqCrudServiceVinculo.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(ICrudService<Vaga, IdVaga>))).Returns(_moqCrudServiceVaga.Object);
            _moqServiceProvider.Setup(x => x.GetService(typeof(ICrudService<DistribuicaoVagaJob, IdJob>))).Returns(_moqCrudServiceJob.Object);
            
            var sut = new DistribuicaoVagaJobApplicationService(_moqIUnitOfWork.Object, _moqServiceProvider.Object);
            var response = Task.WhenAll(sut.UpdateVagaDistributions());

            response.IsFaulted.Should().Be(false);
        }
        
    }
}