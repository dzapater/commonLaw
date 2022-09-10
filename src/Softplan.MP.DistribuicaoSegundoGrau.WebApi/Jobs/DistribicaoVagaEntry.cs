using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.Jobs;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Jobs
{
    public class DistribuicaoVagaJobEntry
    {
        private readonly DistribuicaoVagaJobApplicationService _service;

        public DistribuicaoVagaJobEntry(DistribuicaoVagaJobApplicationService service)
        {
            _service = service;
        }
        public async Task Processar()
        {
            await _service.UpdateVagaDistributions();
        }
    }
}