using System;
using System.Linq.Expressions;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class DescricaoMotivoMembroVagaReadModelContainsSpecification : Specification<MotivoMembroVagaReadModel>
    {
        private readonly string _descricaoMotivoMembroVaga;

        public DescricaoMotivoMembroVagaReadModelContainsSpecification(string descricaoMotivoMembroVaga)
        {
            _descricaoMotivoMembroVaga = descricaoMotivoMembroVaga;
        }

        public override Expression<Func<MotivoMembroVagaReadModel, bool>> ToExpression()
            => x => x.Descricao.Trim().ToLower().Contains(_descricaoMotivoMembroVaga.Trim().ToLower());
    }
}