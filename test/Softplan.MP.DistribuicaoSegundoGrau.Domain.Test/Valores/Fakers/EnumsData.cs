using System;
using System.Collections;
using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Test.Valores.Fakers
{
    public sealed class EnumsData<TEnum> : IEnumerable<object[]>
        where TEnum : struct, Enum
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var listaNosEnums = Enum.GetValues(typeof(TEnum));

            foreach (var enums in listaNosEnums)
            {
                yield return new[] {enums};
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}