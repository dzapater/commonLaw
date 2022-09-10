using System;
using System.Linq;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class SituacaoRegraDistribuicaoEspecialidadeEqualsSpecification : Specification<RegraDistribuicaoEspecialidadeReadModel>
    {
        private readonly Situacao? _situacao;

        public SituacaoRegraDistribuicaoEspecialidadeEqualsSpecification(Situacao? situacao)
        {
            _situacao = situacao;
        }

        public override Expression<Func<RegraDistribuicaoEspecialidadeReadModel, bool>> ToExpression()
        {
            return _situacao switch
            {
                Situacao.Ativa => x => x.Regra.Ativo && x.QuantidadeVinculosAtivos > 0,
                Situacao.Pendente => x => x.Regra.Ativo && x.QuantidadeVinculosAtivos == 0,
                Situacao.Desativada => x => !x.Regra.Ativo,
                _ => x => true
            };
        }
    }
}