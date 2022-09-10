using System;
using System.Runtime.Serialization;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Exceptions
{
    [Serializable]
    public sealed class UsuarioLotacaoNuloException : Exception
    {
        public UsuarioLotacaoNuloException()
            : base($"A lotação do usuário atual está nula") { }        
        private UsuarioLotacaoNuloException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
