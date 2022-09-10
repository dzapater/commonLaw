using System.Collections.Generic;
using System.Threading.Tasks;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX
{
    public interface ITaxGatewayService : IGatewayService
    {
        Task<ICollection<AssuntoResponseMessage>> GetAssuntosByIds(params long[] idsAssunto);
        Task<ClasseResponseMessage> GetClasseById(long idClasse);
        Task<TarjaResponseMessage> GetTarjaById(long idTarja);
        Task<OrgaoJulgadorResponseMessage> GetOrgaoJulgadorById(string idTipoCadastro, long idUnidade, long idOrgaoJulgador);
        Task<UnidadeResponseMessage> GetUnidadeById(string idTipoCadastro, long idUnidade);
    }
}