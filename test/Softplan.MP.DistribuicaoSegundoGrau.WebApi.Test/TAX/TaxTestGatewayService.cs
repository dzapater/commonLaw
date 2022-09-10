using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.TAX
{
    public class TaxTestGatewayService : ITaxGatewayService
    {
        public Task<ICollection<AssuntoResponseMessage>> GetAssuntosByIds(params long[] idsAssunto)
            => Task.FromResult(GetAssuntos(idsAssunto));

        public Task<ClasseResponseMessage> GetClasseById(long idClasse)
            => Task.FromResult(new ClasseResponseMessage
            {
                Id = idClasse,
                Descricao = "Classe Teste"
            });

        public Task<TarjaResponseMessage> GetTarjaById(long idTarja)
            => Task.FromResult(new TarjaResponseMessage
            {
                Id = idTarja,
                Descricao = "Tarja Teste"
            });

        public Task<OrgaoJulgadorResponseMessage> GetOrgaoJulgadorById(string idTipoCadastro, long idUnidade,
            long idOrgaoJulgador)
        {
            if (idTipoCadastro.Equals("0802") && idUnidade.Equals(default) && idOrgaoJulgador.Equals(default))
                return Task.FromResult((OrgaoJulgadorResponseMessage)null);
            
            return Task.FromResult(new OrgaoJulgadorResponseMessage
            {
                Descricao = "Orgao Julgador Teste"
            });
        }

        public Task<UnidadeResponseMessage> GetUnidadeById(string idTipoCadastro, long idUnidade)
            => Task.FromResult(new UnidadeResponseMessage
            {
                Descricao = "Unidade Teste"
            });

        private static ICollection<AssuntoResponseMessage> GetAssuntos(params long[] idsAssunto)
        => idsAssunto.Select(id => new AssuntoResponseMessage { Id = id, Descricao = "Assunto Teste" }).ToList();
        
    }
}