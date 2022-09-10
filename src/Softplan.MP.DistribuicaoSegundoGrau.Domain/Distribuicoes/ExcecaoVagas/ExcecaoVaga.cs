using System.Collections.Generic;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using System.ComponentModel.DataAnnotations.Schema;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Distribuicoes.ExcecaoVagas
{
    public class ExcecaoVaga : IdExcecaoVaga, IDomainModel
    {
        public ExcecaoVaga()
        {
            Origem = new CriterioOrigem { Id = 0, Descricao = string.Empty };
        }

        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public int IdVaga { get; set; }
        public int? IdClasse { get; set; }
        public int? IdAssunto { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdOrigem { get; set; }
        public int? IdUnidade { get; set; }
        public int? IdOrgaoJulgador { get; set; }
        public string Motivo { get; set; }
        public CriterioEspecialidade Especialidade => IdEspecialidade != null ? new CriterioEspecialidade {IdEspecialidade = (long) IdEspecialidade} : null;
        public CriterioAssunto Assunto => IdAssunto != null ? new CriterioAssunto {IdAssunto = (long) IdAssunto} : null;
        public CriterioClasse Classe => IdClasse != null ? new CriterioClasse {IdClasse = (long) IdClasse} : null;        
        [NotMapped]
        public CriterioOrigem Origem { get; set; }
        public CriterioUnidade Unidade => IdOrigem != null && IdUnidade != null ? new CriterioUnidade {IdOrigem = (int)IdOrigem, IdUnidade = (long)IdUnidade} : null;
        public CriterioOrgaoJulgador OrgaoJulgador => IdOrgaoJulgador != null ? new CriterioOrgaoJulgador {IdOrigem = (int)IdOrigem, IdUnidade = (long)IdUnidade, IdOrgaoJulgador = (long)IdOrgaoJulgador} : null;
        public List<string> Mensagens { get; set; } = new List<string>();
    }
}