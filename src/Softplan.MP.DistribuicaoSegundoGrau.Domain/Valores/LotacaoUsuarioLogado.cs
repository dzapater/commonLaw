using System;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores
{
    public sealed class LotacaoUsuarioLogado : IEquatable<LotacaoUsuarioLogado>
    {
        public string Value { get; }

        private LotacaoUsuarioLogado(string lotacaoUsuarioLogadoId)
        {
            Value = lotacaoUsuarioLogadoId ?? string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj is LotacaoUsuarioLogado lotacaoUsuarioLogadoId)
            {
                return Equals(lotacaoUsuarioLogadoId);
            }
            if (obj is string strLotacaoUsuarioLogadoId)
            {
                return Equals(strLotacaoUsuarioLogadoId);
            }
            return false;
        }

        public bool Equals(LotacaoUsuarioLogado other)
        {
            if (other is null)
            {
                return false;
            }
            return other.Value.Equals(Value);
        }

        public bool Equals(string other)
        {
            if (other is null)
            {
                return false;
            }
            return Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator LotacaoUsuarioLogado(string lotacaoUsuarioLogadoId)
        {
            return string.IsNullOrEmpty(lotacaoUsuarioLogadoId) ?
                new LotacaoUsuarioLogado(null) :
                new LotacaoUsuarioLogado(lotacaoUsuarioLogadoId);
        }

        public static implicit operator string(LotacaoUsuarioLogado lotacaoUsuarioLogadoId)
        {
            return lotacaoUsuarioLogadoId.Value;
        }

    }
}
