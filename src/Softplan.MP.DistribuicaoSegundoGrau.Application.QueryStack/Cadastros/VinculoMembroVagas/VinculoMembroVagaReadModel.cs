using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.Vagas;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.Vagas;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas
{
    public class VinculoMembroVagaReadModel
    {
        public VagaReadModel Vaga { get; set; }
        public MotivoMembroVagaReadModel Motivo { get; set; }
        public int Id { get; set; }
        public int IdVaga{ get; set; }
        public string IdMembro { get; set; }
        public int IdMotivoMembroVaga { get; set; }
        public string Observacao { get; set; }
        public DateTimeOffset DataInicial { get; set; }
        public DateTimeOffset? DataFinal { get; set; }
        public ProcuradorTitular Membro => new ProcuradorTitular {Id = IdMembro ?? "-"};
        
        public static Expression<Func<VinculoMembroVagaMotivo, VinculoMembroVagaReadModel>> SelectNew => item =>
            new VinculoMembroVagaReadModel
            {
                Vaga = VagaReadModel.New(item.Vinculo.Vaga),
                Motivo = SetMotivoMembroVagaReadModel(item.Motivos,item.Vinculo.IdMotivoMembroVaga),
                Id=item.Vinculo.Id,
                IdVaga = item.Vinculo.IdVaga,
                IdMembro = item.Vinculo.IdMembro,
                IdMotivoMembroVaga = item.Vinculo.IdMotivoMembroVaga,
                DataInicial = item.Vinculo.DataInicial,
                DataFinal = item.Vinculo.DataFinal,
                Observacao = item.Vinculo.Observacao 
            };

        private static MotivoMembroVagaReadModel SetMotivoMembroVagaReadModel(ICollection<MotivoMembroVagaReadModel> motivos, int IdMotivoMembroVaga)
        {
            foreach (var motivo in motivos)
            {
                if (motivo.Id == IdMotivoMembroVaga)
                    return new MotivoMembroVagaReadModel
                    {
                        Id = motivo.Id,
                        Ativo = motivo.Ativo,
                        Descricao = motivo.Descricao
                    };
            }

            return new MotivoMembroVagaReadModel();
        }
    }
}