using System;
using System.Linq.Expressions;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Specifications
{
    public class AtivoMotivoMembroVagaReadModelEqualsSpecification : Specification<MotivoMembroVagaReadModel>
    {
    private readonly string _ativoMotivoMembroVaga;

    public AtivoMotivoMembroVagaReadModelEqualsSpecification(string ativoMotivoMembroVaga)
    {
        _ativoMotivoMembroVaga = ativoMotivoMembroVaga;
    }

    public override Expression<Func<MotivoMembroVagaReadModel, bool>> ToExpression()
        => x => x.Ativo.Trim().ToLower().Equals(_ativoMotivoMembroVaga.Trim().ToLower());
    }
}