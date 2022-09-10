using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas
{
    public class ValidaVinculoItemVaga
    {
        public ValidaVinculoItemVaga()
        {
            Mensagens = new List<string>();
        }

        public bool Status { get; set; }
        public List<string> Mensagens { get; set; }        
    }
}