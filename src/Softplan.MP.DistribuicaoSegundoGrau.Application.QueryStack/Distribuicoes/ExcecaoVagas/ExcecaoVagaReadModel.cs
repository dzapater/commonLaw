using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVagaReadModel
    {
        public ExcecaoVaga ExcecaoVaga { get; set; }
        public static ExcecaoVagaReadModel New(ExcecaoVaga item) => SelectNew.Compile().Invoke(item);
        private static Expression<Func<ExcecaoVaga, ExcecaoVagaReadModel>> SelectNew => item => new ExcecaoVagaReadModel
        {
            ExcecaoVaga = item
        };
    }
}