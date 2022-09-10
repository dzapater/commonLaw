﻿using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;
using Softplan.MP.Utils.SharedKernel.Specifications;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao.Specifications
{
    public class IdAreaRegraDistribuicaoEqualsSpecification : Specification<RegraDistribuicao>
    {
        private readonly Area? _area;

        public IdAreaRegraDistribuicaoEqualsSpecification(Area? area)
        {
            _area = area;
        }

        public override Expression<Func<RegraDistribuicao, bool>> ToExpression()
            => _area switch
            {
                Area.Ambas => x => x.Area.Equals(Area.Ambas) 
                    || x.Area.Equals(Area.Civel) || x.Area.Equals(Area.Criminal),
                _ => x => x.Area.Equals(_area) || x.Area.Equals(Area.Ambas)
            };
    }
}