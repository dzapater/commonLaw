using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.DistribuicaoProcessos;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.Distribuicao
{
    public class DistribuicaoProcessoReadModel
    {
        public DistribuicaoProcesso DistribuicaoProcesso { get; set; }
        public List<DistribuicaoProcessoLog> DistribuicaoProcessoLog { get; set; } = new List<DistribuicaoProcessoLog>();
        
        public static DistribuicaoProcessoReadModel New(DistribuicaoProcessoReadModel model) => SelectNew.Compile().Invoke(model.DistribuicaoProcesso, model.DistribuicaoProcessoLog);
        private new static Expression<Func<DistribuicaoProcesso, List<DistribuicaoProcessoLog>, DistribuicaoProcessoReadModel>> SelectNew =>
                (processo, log) => MapDistribuicao(processo, log);
        private static DistribuicaoProcessoReadModel MapDistribuicao(DistribuicaoProcesso processo, List<DistribuicaoProcessoLog> logs)
        {
            var distribuicao = new DistribuicaoProcessoReadModel();
            distribuicao.DistribuicaoProcesso = processo;
            foreach (var log in logs)
            {
                distribuicao.DistribuicaoProcesso.AddLog(log.DomainEvent);
                distribuicao.DistribuicaoProcessoLog.Add(log);
            }
            return distribuicao;
        }
    }
}