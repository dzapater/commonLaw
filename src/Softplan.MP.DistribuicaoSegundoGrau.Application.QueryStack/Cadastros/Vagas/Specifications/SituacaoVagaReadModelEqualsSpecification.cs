using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas.Specifications
{
    public class SituacaoVagaReadModelEqualsSpecification : Specification<VagaReadModel>
    { 
        private readonly Situacao? _situacao;

        public SituacaoVagaReadModelEqualsSpecification(Situacao? situacao)
        {
            _situacao = situacao;
        }

        public override Expression<Func<VagaReadModel, bool>> ToExpression()
        {
            return _situacao switch
            {
                Situacao.Ativa => x => x.EstaAtiva && x.MembroEmAtividade.Id != "-" && x.MembroEmAtividade.Id != Situacao.DesativacaoPlanejada.ToString(),
                Situacao.Pendente => x => x.MembroEmAtividade.Id == "-",
                Situacao.Desativada => x => x.MembroEmAtividade.Id == Situacao.DesativacaoPlanejada.ToString() || !x.EstaAtiva,
                _ => x => true
            };           
        }
    }
}