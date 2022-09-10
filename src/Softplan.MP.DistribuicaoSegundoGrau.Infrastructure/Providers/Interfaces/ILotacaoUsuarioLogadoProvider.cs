using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers.Interfaces
{
    public interface ILotacaoUsuarioLogadoProvider
    {
        LotacaoUsuarioLogado Get();
        void SetLotacaoUsuarioLogadoInResponseHeader();
    }
}
