using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class EstaAtivoVagaEqualSpecification : Specification<Vaga>
    {
        private readonly bool _estaAtivo;

        public EstaAtivoVagaEqualSpecification(bool estaAtivo)
        {
            _estaAtivo = estaAtivo;
        }

        public override Expression<Func<Vaga, bool>> ToExpression()
            => x => x.EstaAtiva.Equals(_estaAtivo);
    }
}