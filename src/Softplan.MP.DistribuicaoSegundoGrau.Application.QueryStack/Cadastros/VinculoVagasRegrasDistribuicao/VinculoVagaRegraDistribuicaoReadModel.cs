using System;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.VinculoMembroVagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoVagasRegrasDistribuicao
{
    public class VinculoVagaRegraDistribuicaoReadModel
    {
        public VagaReadModel Vaga { get; set; }
        public RegraDistribuicaoReadModel RegraDistribuicao { get; set; }
        public static Expression<Func<VinculoMembroVaga, VinculoVagaRegraDistribuicaoReadModel>> SelectNew => item => new VinculoVagaRegraDistribuicaoReadModel
        {
            Vaga = VagaReadModelExtension.New(item),
            RegraDistribuicao = RegraDistribuicaoReadModel.New(item.RegraDistribuicao)
        };
    }
}