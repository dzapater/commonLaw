using Microsoft.AspNetCore.Http;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Exceptions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers.Interfaces;
using System;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Providers
{
    public class LotacaoUsuarioLogadoProvider : ILotacaoUsuarioLogadoSetter, ILotacaoUsuarioLogadoProvider
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly Lazy<LotacaoUsuarioLogado> _lazyUsuarioLogadoId;

        private const string USUARIO_LOTACAO_HEADER = "lotacao";

        private LotacaoUsuarioLogado _usuarioLogadoId;
        private bool _usuarioLogadoIdPreviouslySetted = false;
        public LotacaoUsuarioLogado UsuarioLogadoId
        {
            get => _usuarioLogadoId;
        }

        public LotacaoUsuarioLogadoProvider(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
            _lazyUsuarioLogadoId = new Lazy<LotacaoUsuarioLogado>(() =>
            {
                if (_usuarioLogadoIdPreviouslySetted)
                    return UsuarioLogadoId;
                if (!(accessor?.HttpContext?.Request is null))
                {
                    var usuarioLogado = accessor.HttpContext.Request.Headers[USUARIO_LOTACAO_HEADER].ToString();
                    return !string.IsNullOrEmpty(usuarioLogado) ?
                        usuarioLogado :
                        throw new UsuarioLotacaoNuloException();
                }
                return _lazyUsuarioLogadoId.Value;
            });
        }

        public void SetLotacaoUsuarioLogado(LotacaoUsuarioLogado usuarioLogadoId)
        {
            if (!_usuarioLogadoIdPreviouslySetted)
            {
                _usuarioLogadoIdPreviouslySetted = true;
                _usuarioLogadoId = usuarioLogadoId;
            }
            else if (_usuarioLogadoId != usuarioLogadoId)
                throw new UsuarioLotacaoNuloException();
        }

        public LotacaoUsuarioLogado Get()
        {
            return _lazyUsuarioLogadoId.Value;
        }

        public void SetLotacaoUsuarioLogadoInResponseHeader()
        {
            _accessor?.HttpContext?.Response?.Headers?.Add(USUARIO_LOTACAO_HEADER, Get().ToString());
        }
    }
}
